using UnityEngine;

public class Arrow : Obstacle
{
    private float speed = 15f;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, speed * Time.deltaTime);
    }
}
