using UnityEngine;


public class SwipeHandlerSwitcher : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;


    private void OnEnable()
    {
        CharacterStates.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDisable()
    {
        CharacterStates.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
    }
    

    private void OnCharacterGroundedChanged(bool isGrounded)
    {
        _swipeHandler.enabled = isGrounded;
    }
}