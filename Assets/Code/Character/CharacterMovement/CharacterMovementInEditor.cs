using System.Reflection;
using UnityEngine;


public class CharacterMovementInEditor : MonoBehaviour
{
    #if UNITY_EDITOR
    
    private MoveDirection _moveDirection;
    private PropertyInfo _direction;
    private SwipeHandler _swipeHandler;
    private Quaternion _targetRotation;
    

    public void Init(MoveDirection moveDirection, SwipeHandler swipeHandler)
    {
        _moveDirection = moveDirection;
        _swipeHandler = swipeHandler;
        _direction = typeof(MoveDirection).GetProperty("Direction");
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
        
        _direction.SetValue(_moveDirection, direction);
    }

    
    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _targetRotation = GravityDataPresenter.GravityData[gravityDirection].Rotation;
    }

#endif
}
