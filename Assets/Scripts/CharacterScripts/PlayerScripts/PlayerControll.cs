using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float _speedPl;
    [SerializeField] public int _hpPl = 100;
    [SerializeField] public int _bulletsPl = 30;
    [SerializeField] public int _bombsPl = 30;
    [SerializeField] private int _jumpForce = 250;
    [SerializeField] private int _fireBullForce = 4;
    [SerializeField] private int _fireBombForce = 4;

    [SerializeField] private int _imDamagedToBullet;
    [SerializeField] private int _imDamagedToBomb;
    [SerializeField] private int _useMedkit;
    [SerializeField] private int _pickUpAmountAmmo;
    [SerializeField] private int _pickUpAmountBomb;

    [SerializeField] private Vector3 _dirPl; // сериализация для контроля в инспекторе
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private GameObject _playerBomb;
    [SerializeField] private Transform _plBulStartPos;
    [SerializeField] private Rigidbody _rbPl;
    [SerializeField] private Animator _animPl;
    private AudioSource _audioSource;
    //[SerializeField] private GameObject _playerGO;
    //[SerializeField] private float _speedPlVel;

    public float Health = 100f;

    #region mouse data
    //private Vector3 _dirMouse = Vector3.zero;
    private Vector3 _dirMouse;
    private float _mouseX;
    Quaternion qRot;
    [SerializeField] private float _mouseSensity = 5f;
    Transform cameraTransform;
    #endregion

    public bool isAlive { get; private set; }
    public bool onGround;

    private void Awake()
    {
        isAlive = true;
        _rbPl = GetComponent<Rigidbody>();
        _animPl = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        cameraTransform = Camera.main.transform;
        qRot = transform.rotation;
    }

    private void Update()
    {
        _dirPl.x = Input.GetAxis("Horizontal");
        _dirPl.z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.E))
        {
            up();
        }

        if (Input.GetKey(KeyCode.Space))// исп.GetKey вместо GetKeyDown,
            // чтобы от быстрого нажатия прыгал ниже, чем если кнопку заажать
        {
            Jump();
        }

        #region Animation Jump
        if (onGround)
        {
            _animPl.SetBool("Jump", false);
        }
        else
        {
            _animPl.SetBool("Jump", true);
        }
        #endregion

        #region Attacks methods

        if (Input.GetMouseButtonDown(0))
        {
            _animPl.SetBool("Fire", true); 
            // Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            _animPl.SetBool("FireBomb", true); // анимация подвисает
           // Bomb();
        }

        #endregion

    }
    private void FixedUpdate()
    {
         MovePlayer();
        _mouseX += Input.GetAxis("Mouse X") * _mouseSensity;
        Quaternion rotY = Quaternion.AngleAxis(_mouseX, Vector3.up);
        _rbPl. transform.rotation = qRot * rotY;
    }

    private void MovePlayer()
    {
        var speed = _dirPl * _speedPl * Time.fixedDeltaTime;
        _rbPl.AddRelativeForce(_dirPl * _speedPl,ForceMode.VelocityChange);

        #region Animation Run
        if (speed != Vector3.zero)
        {
            _animPl.SetBool("Run", true);
        }
        else
        {
            _animPl.SetBool("Run", false);
        }
        #endregion

        #region TEST 
        //_rbPl.velocity = transform.TransformVector(new Vector3(_dirPl.x,  0, _dirPl.z) * _speedPl); //бег работает, но проблема с прыжком...
        //_rbPl.transform.position = transform.position + speed; //перемещение пот глобальным координатам
        //_rbPl.AddForce(0, _jumpForce, 0, ForceMode.Impulse);

        // transform.Translate(speed);// remake to Physics.rigidBody
        #endregion
    }

    private void Fire()
    {
        if (_bulletsPl > 0)
        {
            var bul= Instantiate(_playerBullet, _plBulStartPos.position, _plBulStartPos.rotation);//Quaternion rotation { get; set; }
            bul.GetComponent<Rigidbody>().AddForce(transform.forward * _fireBullForce,ForceMode.Impulse);
            _bulletsPl = _bulletsPl - 1;
            _audioSource.Play();
        }
        _animPl.SetBool("Fire", false);
    }

    private void Bomb()
    {
        if (_bombsPl > 0)
        {
            var bomb = Instantiate(_playerBomb, _plBulStartPos.position, _plBulStartPos.rotation);//Quaternion rotation { get; set; }
                                                                                                    // bul.in
            bomb.GetComponent<Rigidbody>().AddForce(transform.forward * _fireBombForce, ForceMode.Force);
            _bombsPl --;
        }
        _animPl.SetBool("FireBomb", false);
    }

    private void Jump()
    {
        if (onGround)
        {
        _rbPl.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
        }
    }

    public void Healing(int damage)
    {
        _hpPl += damage;
    }

    public void Hurt(int damage)
    {
        _hpPl -= damage;

        if (_hpPl <= 0 && isAlive)
        {
            Die();
        }
    }

    public void PickUpBullet(int damage)
    {
        _bulletsPl = _bulletsPl + _pickUpAmountAmmo;//_bulletsPl++; ???
    }

    public void PickUpBomb(int damage)
    {
        _bombsPl = _bombsPl + _pickUpAmountBomb;//_bombsPl++; ???
    }

    private void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    private void CheckGround()
    {
        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.CompareTag("Ground"))
        //    {
        //        onGround = false;
        //        print("onGround false");
        //    }
        //}
    }

    private void up()
    {
        _rbPl.AddForce( 0,_jumpForce * .05f, 0, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" || col.tag == "Bul_1")
        {
            Hurt(_imDamagedToBullet);
        }

        if (col.gameObject.CompareTag("Bomb"))
        {
            Hurt(_imDamagedToBomb);
        }

        if (col.gameObject.CompareTag("MedK"))
        {
            Healing(_useMedkit);
        }

        if (col.gameObject.CompareTag("Ammo_1"))
        {
            PickUpBullet(1);// amount gameObj Ammo_1
        }

        if (col.gameObject.CompareTag("BombItem"))
        {
            PickUpBomb(1);//amount gameObj BombItem
        }

        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            print("onGround true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            print("onGround false");
        }
    }

    //////////////////////////////////////////////////////////////////////
    //  transform.rotation = qRot * rotY;
    //cameraTransform.transform.position = _rbPl.position;
    //cameraTransform.transform.rotation = qRot * rotY;

    #region Jump animation for Update
    //if(Mathf.Abs(_rbPl.velocity.y) > 0.1f)
    //{
    //    _animPl.SetBool("Jump", true);
    //}
    //else
    //{
    //    _animPl.SetBool("Jump", false);
    //}
    #endregion
}