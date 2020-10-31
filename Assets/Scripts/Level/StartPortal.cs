using System.Collections;
using UnityEngine;

public class StartPortal : MonoBehaviour
{
    private float speed = 1f;
    private float speed_of_disappearing;
    private Vector3 disappear_vector;

    private float time_before_disappearance = 1.3f;

    private void Start()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(time_before_disappearance);

        while (transform.localScale.x >= 0)
        {
            speed_of_disappearing = speed * Time.deltaTime;
            disappear_vector = new Vector2(speed_of_disappearing, speed_of_disappearing);

            transform.localScale -= disappear_vector;
            yield return new WaitForFixedUpdate();
        }

        Destroy(gameObject);
    }
}
