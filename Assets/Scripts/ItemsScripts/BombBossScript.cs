using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBossScript : MonoBehaviour
{
    [SerializeField] private GameObject _bombPos;
    [SerializeField] private float _exploseForce = 1;
    [SerializeField] private float _exploseRadius = 1;
    [SerializeField] private float _bombSpeed = 4f;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionParticleSystem;

    private Transform _target;
    private GameObject _player;

    // public UnityEvent detonateOn;

    private void Awake()
    {
        _player = GameObject.Find("PlayerGO");
    }

    void Start()
    {
        _target = _player.transform;
        //_bombStartPos = _bombPos;
        // _bombStartPos = new Vector3();//public static float Angle(Vector3 from, Vector3 to);
        //public void Set(float newX, float newY, float newZ);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _bombSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            _explosionParticleSystem.Play();
            print("BOOM!");
            ExplosionBomb(_bombPos.transform.position, _exploseForce);
            //Invoke("ExplosionBomb", 0.2f);
        }
    }

    private void ExplosionBomb(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(_bombPos.transform.position, _exploseRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.attachedRigidbody)
            {
                hitCollider.attachedRigidbody.AddForce(-(_bombPos.transform.position - hitCollider.transform.position) * _exploseForce, ForceMode.Impulse);
            }
        }
        Destroy(gameObject, 0.1f);
        //detonateOn?.Invoke();
    }
    /////////////////////////////////////////////////////////////

}
