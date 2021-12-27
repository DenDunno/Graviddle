using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandlerSwitcher : CharacterFallingEventsHandler, IDragHandler
{
    [SerializeField] private SwipeHandler _swipeHandler = null;


    protected override void OnCharacterStartFalling()
    {
        _swipeHandler.enabled = false;
    }


    protected override void OnCharacterEndFalling()
    {
        _swipeHandler.enabled = true;
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}