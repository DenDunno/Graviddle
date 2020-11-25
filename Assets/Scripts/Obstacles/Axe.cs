using UnityEngine;

public class Axe : Obstacle
{
    [SerializeField]
    private float _speed = 5f; //скорость туда-сюда

    [SerializeField]
    private float _angle = 30; //величина размаха

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * _speed) * _angle);
    }
}


