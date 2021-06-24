using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<GravityDirection> GravityChanged;
    private GravityDirection _gravityDirection;
    private float _swipeSensitivity = 1.0f;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 swipeInput = new Vector2(eventData.delta.x, eventData.delta.y);
        
        if (swipeInput.magnitude > _swipeSensitivity)
        {
            DefineTurn(ref swipeInput);
            GravityChanged?.Invoke(_gravityDirection);
        }
    }


    private void DefineTurn(ref Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            _gravityDirection = delta.x < 0 ? GravityDirection.Left : GravityDirection.Right;
        }

        else
        {
            _gravityDirection = delta.y < 0 ? GravityDirection.Down : GravityDirection.Up;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}
