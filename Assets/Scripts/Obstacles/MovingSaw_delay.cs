using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw_delay : Moving_saw
{
    [SerializeField]
    private float wait_time = 2f;

    protected override void Change_target(ref Vector3 target)
    {
        base.Change_target(ref target);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        float temp = speed;
        speed = 0;
        yield return new WaitForSeconds(wait_time);
        speed = temp;
    }
}
