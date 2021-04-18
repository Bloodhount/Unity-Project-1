using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static LightingSettings LightingSettings;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
