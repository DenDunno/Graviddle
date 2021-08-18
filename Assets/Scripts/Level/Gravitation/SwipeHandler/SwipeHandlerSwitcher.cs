using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandlerSwitcher : MonoBehaviour , IDragHandler
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

    public void OnDrag(PointerEventData eventData)
    {
    }
}