using UnityEngine;

public class Axe : Obstacle
{
    [SerializeField]
    private float speed = 5f; //скорость туда-сюда

    [SerializeField]
    private float angle = 30; //величина размаха

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * speed) * angle);
    }
}


