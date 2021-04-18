using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_4_Doors : MonoBehaviour
{
    private bool _open = false;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Open()
    {
        _open = true;
        _anim.SetBool("Open door 2  Animation", true);
    }

    public void Close()
    {
        _open = false;

        _anim.SetBool("Open door 2  Animation", false);
    }
}
