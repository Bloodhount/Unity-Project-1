using UnityEngine;
using UnityEngine.AI;

public class Enemy_2 : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _speedRot = 2;
    [SerializeField] private float _attackDist = 5f;
    [SerializeField] private float _reloadTime;
    [SerializeField] private int _healthEnemy_2 = 5;
    [SerializeField] private int _fireBullForce = 10;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _startBulletPos;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _pickUp;
    [SerializeField] private int _damageBull;
    [SerializeField] private int _damageBomb;
    [SerializeField] private Vector3 _dirEnemy;

    private Animator _animEnemy;
    private Rigidbody _rbEn_2;
    private Vector3 _startEnemyPos;
    private AudioSource _audioSource;

    private bool _reloaded = true;

    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    public bool isAlive { get; private set; }

    int m_CurrentWaypointIndex;

    void Awake()
    {
        isAlive = true;
        _player = GameObject.Find("PlayerGO");
        _rbEn_2 = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _animEnemy = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _target = _player.transform;
        _dirEnemy.x = _rbEn_2.velocity.x;
        _dirEnemy.z = _rbEn_2.velocity.z;
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
       // _currReloadTime -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target.position) < _attackDist && _reloaded)
        {
            Vector3 dir = _target.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, _speedRot * Time.fixedDeltaTime, 10f);
            transform.rotation = Quaternion.LookRotation(newDir);
            Fire();
        }

        //_currReloadTime -= Time.fixedDeltaTime;

        if (_rbEn_2.velocity.x != 0 || _rbEn_2.velocity.z != 0)
        {
            _animEnemy.SetBool("Run", true);
        }
        else
        {
            _animEnemy.SetBool("Run", false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bul_1"))
        {
            EnemyHurt2(_damageBull);
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            EnemyHurt2(_damageBomb);
        }

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    InvokeRepeating("Fire", 0.5f, 10);
        //    // Fire();
        //}
    }

    private void InitBullet()
    {
        //Instantiate(_bullet, _startBulletPos.position, transform.rotation);
        var bul = Instantiate(_bullet, _startBulletPos.position, transform.rotation);//Quaternion rotation { get; set; }
                                                                                     // bul.in
        bul.GetComponent<Rigidbody>().AddForce(transform.forward * _fireBullForce, ForceMode.Impulse);
    }

    private void Fire()
    {
        _audioSource.Play();
        InitBullet();
        _reloaded = false;
        Invoke("Reload", _reloadTime);
        //InvokeRepeating("InitBullet", 0.5f, 0.5f); 
        //var bul = Instantiate(_bullet, _startBulletPos.position, transform.rotation);//.GetComponent<Bullet>();
        //bul.Init(_player.transform, damage);
    }

    private void Reload()
    {
        _reloaded = true;
    }

    public void EnemyHurt2(int damage)
    {
        _healthEnemy_2 -= damage;

        if (_healthEnemy_2 <= 0 && isAlive)
        {
            EnemyDie2();
        }
    }

    private void EnemyDie2()
    {
        isAlive = false;
        gameObject.SetActive(false);
        Instantiate(_pickUp, transform.position, transform.rotation);
    }

    /////////////////////////////////////////////////////////////
    //private void EnemyRotation()
    //{
    //    //Vector3 pos = _target.position - transform.position;
    //    //transform.rotation = Quaternion.LookRotation(pos);
    //    //transform.LookAt(_target);
    //}
    //private void MoveToPlayer()
    //{
    //    //transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    //}
    //private void EnemyGo()
    //{
    //    //transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
    //}

}
