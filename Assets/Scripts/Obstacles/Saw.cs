using UnityEngine;

public class Saw : Obstacle
{
    // когда екран черный, преятствие проходит какой-то путь, поэтому коректируем правильную точку респауна 
    [SerializeField]
    private float _correlation = 2f;

    [SerializeField]
    protected float _speed = 4;

    [SerializeField]
    protected float _distance = 1;

    [SerializeField]
    protected bool _goRight = true;

    protected Vector3 _start;
    protected Vector3 _target;
    protected Vector3 _temp;


    virtual protected void Start()
    {
        RestartPosition = transform.position + _correlation * transform.right;
        _start = transform.position;
        _target = _start + transform.right * _distance * (_goRight ? 1 : -1);
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, _target) <= Vector2.kEpsilon)
            ChangeTarget();

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }


    protected virtual void ChangeTarget()
    {
        _temp = _start;
        _start = _target;
        _target = _temp;
    }
}

