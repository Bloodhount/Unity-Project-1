using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _targ;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 screenMousePos = Input.mousePosition;
        Vector3 worldMousePos = _camera.ScreenToWorldPoint(screenMousePos);
        transform.LookAt(screenMousePos);
    }
}
