using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speedBullet = 2;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTimeBullet;
    //[SerializeField] private GameObject _bullet;
    private Transform _target;
   // [SerializeField] private Vector3 _impulsePow;

    void Start()
    {
        Destroy(gameObject, _lifeTimeBullet);
    }

    private void FixedUpdate()
    {
        //transform.position += CalcSpeedBullet(_speedBullet);
    }

    private Vector3 CalcSpeedBullet(float dir)
    {

        return transform.forward * Time.fixedDeltaTime * dir;
    }



    public void Init(Transform target, int damage)
    {
        _target = target;
        _damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {
            print("BOOM!");
        }
        #region
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    var enemy = collision.gameObject.GetComponent<Enemy>();
        //    Init(_target, 1);
        //    enemy.Hurt(_damage);
        //}

        //if (collision.gameObject.CompareTag("Player")) 
        //{
        //  //  Init();
        //    var pl = collision.gameObject.GetComponent<PlayerControll>();
        //    pl.Hurt(_damage);
        //}
        #endregion
    }
}
