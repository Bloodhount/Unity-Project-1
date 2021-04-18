using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _bombPos;
    [SerializeField] private float _exploseForce = 1;
    [SerializeField] private float _exploseRadius = 1;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionParticleSystem;
    private AudioSource _audioSource;
    // public UnityEvent detonateOn;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        //_bombStartPos = _bombPos;
       // _bombStartPos = new Vector3();//public static float Angle(Vector3 from, Vector3 to);
                                      //public void Set(float newX, float newY, float newZ);
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            _audioSource.Play();
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
                hitCollider.attachedRigidbody.AddForce(-(_bombPos.transform.position - hitCollider.transform.position) * _exploseForce,ForceMode.Impulse);
            }
        }
        Destroy(gameObject, 0.5f);
        //detonateOn?.Invoke();
    }
    /////////////////////////////////////////////////////////////
        #region test
        //var _wayToTgt = new Vector3();
        //_wayToTgt = _bombStartPos - _bombTargetPos;

        //Rigidbody.AddForceAtPosition
        //void ApplyForce(Rigidbody body)
        //{
        //    Vector3 direction = body.transform.position - transform.position;
        //    body.AddForceAtPosition(direction.normalized, transform.position);
        //}

        //Physics.OverlapSphere
        //        void ExplosionDamage(Vector3 center, float radius)
        //{
        //    Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        //    foreach (var hitCollider in hitColliders)
        //    {
        //        hitCollider.SendMessage("AddDamage");
        //    }
        //}
        #endregion
}
