using UnityEngine;

public class CharacterMovementInEditor : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField] private MoveDirection _moveDirection;
    
    
    private void Start()
    {
        _moveDirection.enabled = false;
    }


    private void Update()
    {
        //MovementState state = (int)Input.GetAxisRaw("Horizontal");
    }
    
    #endif
}
