using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChekPointScript : MonoBehaviour
{
private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
            print("CheckPoint");
            Debug.Log("CheckPoint");
        }
    }
}
