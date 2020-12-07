using System.Collections;
using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private static bool _enabled = true;

    private void Start()
    {
        _enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.GetComponent<Character>();

        if (character && _enabled)
            StartCoroutine(character.Die());
    }

    public static IEnumerator SwitchOff()
    {
        _enabled = false;
        yield return new WaitForSeconds(3f);
        _enabled = true;
    }
}
