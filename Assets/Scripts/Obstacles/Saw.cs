using UnityEngine;

public class Saw : Obstacle
{
    [SerializeField]
    protected float speed = 4;

    [SerializeField]
    protected float distance = 1;

    [SerializeField]
    protected bool goRight = true;

    protected Vector3 start;
    protected Vector3 target;
    protected Vector3 temp;

    private void Start()
    {
        start = transform.position;
        target = start + transform.right * distance * (goRight ? 1 : -1);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target) <= Vector2.kEpsilon)
            ChangeTarget();

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    protected virtual void ChangeTarget()
    {
        temp = start;
        start = target;
        target = temp;
    }
}

