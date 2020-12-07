using System;
using UnityEngine;


public class FinishPortal : Portal 
{
    static public bool IsPLaying { get; private set; }

    [SerializeField]
    private GameObject _winPanel = null;

    protected override void Start()
    {
        _start = transform.position;
        _target = _start + transform.up * _distance;
        _period = (float)(2 * Math.PI / _speed);
        IsPLaying = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character && Character.IsAlive)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            IsPLaying = false;
            character.Disappear();
            StartCoroutine(Disappear());
            _winPanel.SetActive(true);
        }
    }
}
