using UnityEngine;


public class CharacterRestart : MonoBehaviour, IRestartableComponent , IAfterRestartComponent
{
    [SerializeField] private CharacterTransparency _characterTransparency = null;
    [SerializeField] private Rigidbody2D _characterRigidbody = null;


    void IRestartableComponent.Restart()
    {
        _characterRigidbody.velocity = new Vector2(0, 0);
        _characterTransparency.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _characterTransparency.BecomeOpaque(this);
    }
}