using System.Collections;
using UnityEngine;

public class MovingSawDelay : MovingSaw
{
    [SerializeField]
    private float wait_time = 2f;
    protected override void ChangeTarget(ref Vector3 target)
    {
        base.ChangeTarget(ref target);
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
