using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUnvisibleLock : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}
