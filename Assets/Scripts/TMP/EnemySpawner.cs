using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] public Transform[] waypoints;
    public GameObject enemy;
    public NavMeshAgent navMeshAgent;

    private int _CurrentWaypointIndex;
    private GameObject _currEnemy;

    private void Awake()
    {
        var currEnemy = Instantiate(enemy, transform.position, Quaternion.identity).GetComponent<Enemy_1ScriptForNav>();
        currEnemy.Init(waypoints);
    }

    void Start()
    {
    }

    void Update()
    {
        //if (waypoints != null)
        //{
        //    if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        //    {
        //        _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % waypoints.Length;
        //        navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
        //    }
        //}
    }
}
