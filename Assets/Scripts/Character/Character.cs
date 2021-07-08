using System;
using UnityEngine;


[RequireComponent(typeof(CharacterTransparency))]
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour , IRestartableComponent , IAfterRestartComponent
{
    public event Action CharacterDied = null;

    [SerializeField] private CharacterStates _characterStates = null;
    private CharacterTransparency _characterTransparency;
    private Rigidbody2D _rigidbody;

    
    private void Awake()
    {
        _characterStates.Init(this , Die);

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


    private void Die()
    {
        CharacterDied?.Invoke();
    }
}



