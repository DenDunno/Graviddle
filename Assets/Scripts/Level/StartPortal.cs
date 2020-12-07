using System;
using System.Collections;
using UnityEngine;

public class StartPortal : Portal
{
    protected override void Start()
    {
        _start = transform.position;
        _target = _start;
        _period = (float)(2 * Math.PI / _speed);
        StartCoroutine(Disappear());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }
}
