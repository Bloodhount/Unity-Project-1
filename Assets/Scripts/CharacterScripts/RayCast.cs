using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField] LayerMask _mask;
    [SerializeField] int _range;

    private GameObject _owner;

    private void Awake()
    {
        _owner = GameObject.Find("PlayerGO");
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray();
        ray.origin = _owner.transform.position;
        ray.direction = transform.forward;
        Debug.DrawRay (_owner.transform.position, transform.forward * 10f, Color.red);

        //RaycastHit r = Physics.Raycast(transform.position, Vector3.forward, _range, _mask);
        //if (r)
        //{
        //    print(r.collider.gameObject.name);
        //}
        //Debug.DrawRay(transform.position, Vector3.forward * _range, Color.red);
    }
}
