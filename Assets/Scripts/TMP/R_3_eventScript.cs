using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class R_3_eventScript : MonoBehaviour
{
    public UnityEvent buuttOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BOX_KEY")) ;
        {
            buuttOn?.Invoke();

        }
    }

}
