using System.Reflection;
using UnityEngine;


public class CharacterMovementInEditor : MonoBehaviour
{
    #if UNITY_EDITOR
    
    private CharacterMoveDirection _characterMoveDirection;
    private PropertyInfo _direction;
    private SwipeHandler _swipeHandler;
    private Quaternion _targetRotation;
    

    public void Init(CharacterMoveDirection characterMoveDirection, SwipeHandler swipeHandler)
    {
        _characterMoveDirection = characterMoveDirection;
        _swipeHandler = swipeHandler;
        _direction = typeof(CharacterMoveDirection).GetProperty("Direction");
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDestroy()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Update()
    { 
        var state = (int)Input.GetAxisRaw("Horizontal");
        
        Vector2 direction = _targetRotation * (Vector2.right * state);
        
        _direction.SetValue(_characterMoveDirection, direction);
    }

    
    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _targetRotation = GravityDataPresenter.GravityData[gravityDirection].Rotation;
    }

#endif
}
