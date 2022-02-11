using UnityEngine;


public class CharacterMovementInEditor : MonoBehaviour
{
    private MoveDirection _moveDirection;
    
    
    private void Start()
    {
        #if !UNITY_EDITOR
        enabled = false;
        return;
        #endif

        _moveDirection = FindObjectOfType<MoveDirection>();
    }


    private void Update()
    {
        var movement = (MovementState)Input.GetAxisRaw("Horizontal");
        
        _moveDirection.SetMovementDirection(movement);
    }
}
