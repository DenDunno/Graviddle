using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterPhysicsRestart : MonoBehaviour, IRestartableComponent 
{
    private Rigidbody2D _characterRigidbody;


    private void Start()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
    }


    void IRestartableComponent.Restart()
    {
        _characterRigidbody.velocity = Vector2.zero;
    }
}