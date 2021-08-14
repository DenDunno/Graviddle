using UnityEngine;


public class SwipeHandlerSwitcher : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;


    private void Start()
    {
        CharacterStates.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDestroy()
    {
        CharacterStates.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
    }


    private void OnCharacterGroundedChanged(bool isGrounded)
    {
        _swipeHandler.enabled = isGrounded;
    }
}