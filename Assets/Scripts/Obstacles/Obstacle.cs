using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character)
            StartCoroutine(character.Die());
    }
}
