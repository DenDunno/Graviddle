using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterRestart : MonoBehaviour, IRestartableComponent , IAfterRestartComponent
{
    [SerializeField] private CharacterTransparency _characterTransparency = null;
    private Rigidbody2D _characterRigidbody;


    private void Start()
    {
        _characterRigidbody = GetComponent<Rigidbody2D>();
    }


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