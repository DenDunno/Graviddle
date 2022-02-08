using UnityEngine;


public class Character : MonoBehaviour, IMediator
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    
    public void Resolve()
    {
        var characterRotationImpulse = new CharacterRotationImpulse(_swipeHandler, _rigidbody2D);
    }
}