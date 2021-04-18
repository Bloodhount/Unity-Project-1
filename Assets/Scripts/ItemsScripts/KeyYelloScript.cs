using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyYelloScript : MonoBehaviour
{
    [SerializeField] private GameObject _openedDoor;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        _openedDoor = GameObject.Find("wall R6 exit door");
        //gameObject.GetComponent<>(KeyYelloScript)._openedDoor = _openedDoor;
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        Destroy(_openedDoor, 0.6f);
    }
}
