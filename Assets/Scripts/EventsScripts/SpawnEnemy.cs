using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;
    [SerializeField] private GameObject _enemy;
   // [SerializeField] private GameObject _enemyTransform;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] public int _maxEnemyCount = 5;
    private int _enemyCount;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void CreateEnemy()
    {
        if (_enemyCount < _maxEnemyCount)
        {
            _audioSource.Play();
            print("(CreateEnemy, 1, 5)");
            var currEnemy = Instantiate(_enemy, enemySpawnPoint.transform.position, Quaternion.identity).GetComponent<Enemy_1ScriptForNav>();
            currEnemy.Init(waypoints);
            _enemyCount++;
        }
        //else
        //{
        //    CancelInvoke("CreateEnemy");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InvokeRepeating("CreateEnemy", 0.5f, 3);
           // print("(CreateEnemy, 1, 5)");
            //var currEnemy = Instantiate(_enemy,enemySpawnPoint. transform.position, Quaternion.identity).GetComponent<Enemy_1ScriptForNav>();
            //currEnemy.Init(waypoints);
            Destroy(gameObject, 1.6f);
        }
    }
}
