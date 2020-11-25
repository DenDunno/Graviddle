using UnityEngine;

public class Arrow : Obstacle
{
    private float _speed = 15f;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, _speed * Time.deltaTime);
    }
}
