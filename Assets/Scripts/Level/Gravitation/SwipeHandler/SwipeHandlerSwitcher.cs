using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandlerSwitcher : CharacterFallingEventsHandler , IDragHandler
{
    [SerializeField] private SwipeHandler _swipeHandler = null;


    protected override void OnCharacterFalling()
    {
        _swipeHandler.enabled = false;
    }


    protected override void OnCharacterGrounded()
    {
        _swipeHandler.enabled = true;
    }
    

    public void OnDrag(PointerEventData eventData)
    {
    }
}