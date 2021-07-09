using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterRestart : MonoBehaviour, IRestartableComponent, IAfterRestartComponent
{
    [SerializeField] private CharacterTransparency _characterTransparency = null;
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void IRestartableComponent.Restart()
    {
        _rigidbody.velocity = new Vector2(0, 0);
        _characterTransparency.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _characterTransparency.BecomeOpaque(this);
    }
}