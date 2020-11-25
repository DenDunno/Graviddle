using System;
using UnityEngine;

// портал должен двигаться вверх-вниз. Идентичный функционал есть в пилы с ускорением
// OnTriggerEnter2D здесь переписаный, поэтому персонаж не умрет :)
public class FinishPortal : SawAcceleration 
{
    [SerializeField]
    private GameObject _winPanel = null;

    static public bool IsPLaying { get; private set; }


    private void Start()
    {
        _start = transform.position;
        _target = _start + transform.up / 8;
        _period = (float)(2 * Math.PI / _speed);
    }

    private void FixedUpdate()
    {
        IsPLaying = !_winPanel.activeInHierarchy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character && Character.IsAlive)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;


            _winPanel.SetActive(true);

        }
    }
}
