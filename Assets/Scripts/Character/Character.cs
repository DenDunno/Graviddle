using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(CharacterTransparency))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour , IRestartableComponent , IAfterRestartComponent
{
    [SerializeField] private UnityEvent Died = null;

    private Rigidbody2D _rigidbody;
    private CharacterTransparency _characterTransparency;

    
    private void Awake()
    {
        CharacterStates.Init(this , Died);

        _rigidbody = GetComponent<Rigidbody2D>();
        _characterTransparency = GetComponent<CharacterTransparency>();
    }


    void IRestartableComponent.Restart()
    {        
        _rigidbody.velocity = new Vector2(0, 0);
        _characterTransparency.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _characterTransparency.BecomeOpaque();
    }
}



