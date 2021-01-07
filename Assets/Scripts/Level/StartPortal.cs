using System;
using System.Collections;
using UnityEngine;

public class StartPortal : TargetPortal
{
    protected override void Start()
    {
        _start = transform.position;
        _target = _start;
        _period = (float)(2 * Math.PI / _speed);
        StartCoroutine(Disappear());
    }


    public override void Restart()
    {
        transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(Disappear());
    }
}
