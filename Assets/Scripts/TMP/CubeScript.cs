using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private bool _op = false;
    [SerializeField] private float _speed;
    private MeshRenderer _mr;
    public Texture t;

    private void Start()
    {
        _mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (_op)
        {
            transform.Rotate(Vector3.up * _speed * Time.deltaTime);

        }
    }
    public void Op()
    {
        _op = true;
        _mr.material.SetTexture("cr64lb", t);
    }
}
