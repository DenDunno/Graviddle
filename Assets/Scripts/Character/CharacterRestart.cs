using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterTransparency))]
public class CharacterRestart : MonoBehaviour, IRestartableComponent , IAfterRestartComponent
{
    private Rigidbody2D _characterRigidbody;
    private CharacterTransparency _characterTransparency;


    private void Start()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
        _characterTransparency = GetComponent<CharacterTransparency>();
    }


    void IRestartableComponent.Restart()
    {
        _characterRigidbody.velocity = Vector2.zero;
        _characterTransparency.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _characterTransparency.BecomeOpaque();
    }
}