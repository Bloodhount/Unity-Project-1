using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private GameObject _target1;
    [SerializeField] private GameObject _target2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("NextLevel");
            Debug.Log("NextLevel");
            _target1.gameObject.SetActive(false);
            _target2.gameObject.SetActive(false);
            Application.Quit();
        }
    }
}
