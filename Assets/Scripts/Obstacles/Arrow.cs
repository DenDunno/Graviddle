using UnityEngine;


public class Arrow : MonoBehaviour , IObstacle
{
    private readonly float _speed = 15f;


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, _speed * Time.deltaTime);
    }
}
