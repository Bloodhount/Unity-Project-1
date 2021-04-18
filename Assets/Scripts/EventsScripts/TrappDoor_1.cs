using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrappDoor_1 : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private GameObject _door1;
    [SerializeField] private GameObject _door2;
    private AudioSource _audioSource;
    //public UnityEvent doorsOn;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")) ;
    //    {
    //        doorsOn?.Invoke();
    //    }
    //}

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
            Destroy(_obj, 0.6f);
            Destroy(_door1);
            Destroy(_door2);
            print("TrappActivated");
            Debug.Log("TrappActivated");
        }
    }

    private void Start()
    {
        //_door3 = GameObject.Find("wall R6 exit door");
        //gameObject.GetComponent<TrappDoor_1>()._door3 = _door3;
    }

}
