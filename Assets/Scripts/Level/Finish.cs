using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character)
        {
            int active_scene = SceneManager.GetActiveScene().buildIndex;

            //SceneManager.LoadScene(active_scene);
            character.Die();
           
        }

        
    }
}
