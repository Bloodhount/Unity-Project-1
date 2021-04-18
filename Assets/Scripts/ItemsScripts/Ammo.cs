using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private GameObject _playerCollect;
    [SerializeField] private GameObject _ammo;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        Destroy(gameObject, 0.5f);
    }
}
