using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject win_panel = null;

    static public bool IsPLaying  { get; private set; }


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
