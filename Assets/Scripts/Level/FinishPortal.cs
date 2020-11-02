using System;
using UnityEngine;

// портал должен двигаться вверх-вниз. Идентичный функционал есть в пилы с ускорением
// OnTriggerEnter2D здесь переписаный, поэтому персонаж не умрет :)
public class FinishPortal : SawAcceleration 
{
    [SerializeField]
    private GameObject win_panel = null;

    static public bool IsPLaying { get; private set; }


    private void Start()
    {
        start = transform.position;
        target = start + transform.up / 8;
        period = (float)(2 * Math.PI / speed);
    }

    private void FixedUpdate()
    {
        IsPLaying = !win_panel.activeInHierarchy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character && character.IsAlive)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;


            win_panel.SetActive(true);

        }

    }
}
