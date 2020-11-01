using System.Collections;
using UnityEngine;

public class SawDelay : Saw
{
    [SerializeField]
    private float wait_time = 2f;
    protected override void ChangeTarget()
    {
        base.ChangeTarget();
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
