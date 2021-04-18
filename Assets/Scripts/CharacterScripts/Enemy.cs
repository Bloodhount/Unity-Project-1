using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbEn;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pickUp;
    [SerializeField] private int _damageBull;
    [SerializeField] private int _damageBomb;
    [SerializeField] private int _healing;
    [SerializeField] private int _healthEnemy = 7;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float seeDist = 4f;
    [SerializeField] private Animator _animEnemy;
    [SerializeField] private Vector3 _dirPl;

    private Vector3 _startEnemyPos;
    private AudioSource _audioSource;

    public NavMeshAgent _navMeshAgent;
    public Transform[] _waypoints;

    public bool isAlive { get; private set; }

    int _CurrentWaypointIndex;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        isAlive = true;
        _player = GameObject.Find("PlayerGO");
        _rbEn = GetComponent<Rigidbody>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animEnemy = GetComponent<Animator>();
    }

    private void Start()
    {
        _target = _player.transform;
    }

    private void Update()
    {

        //while (isAlive)   // Unity зависает
        //{
        //    print("isAlive");
        //}
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target.transform.position) < seeDist)
        {
            Debug.Log("Player detect");
            MoveToPlayer();
        }

        else if (_waypoints != null)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % _waypoints.Length;
                _navMeshAgent.SetDestination(_waypoints[_CurrentWaypointIndex].position);
            }
        }

        if (_speed != 0)
        {
            _animEnemy.SetBool("Run", true);
        }
        else
        {
            _animEnemy.SetBool("Run", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _target.position = _player.transform.position;
            MoveToPlayer();
        }

        if (other.gameObject.CompareTag( "Bul_1"))
        {
            EnemyHurt(_damageBull);
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            EnemyHurt(_damageBomb);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _audioSource.Play();
        Healing(_healing);
    }

    private void MoveToPlayer()
    {
       _navMeshAgent.SetDestination(_target.position);
      //  transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void Healing(int damage)
    {
        _healthEnemy += damage;
    }

    public void EnemyHurt(int damage)
    {
        _healthEnemy -= damage;

        if (_healthEnemy <= 0 && isAlive)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        isAlive = false;
        gameObject.SetActive(false);
        Instantiate(_pickUp, transform.position, transform.rotation);
    }

    ///////////////////////////////////////////////////////////////////////////////

    //private void EnemyRotation()
    //{
    //    //Vector3 pos = _target.position - transform.position;
    //    //transform.rotation = Quaternion.LookRotation(pos);
    //    transform.LookAt(_target);
    //}

    //private void EnemyGo()
    //{
    //    transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
    //}

    //private void Attack()
    //{
    //}
}