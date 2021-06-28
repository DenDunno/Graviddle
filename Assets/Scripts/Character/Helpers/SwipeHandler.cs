using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<GravityDirection , bool> GravityChanged;

    private readonly int _numOfDirections = 4;

    private GravityDirection _newDirection;
    private GravityDirection _lastDirection;
    private float _swipeSensitivity = 1.0f;
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 swipeInput = new Vector2(eventData.delta.x, eventData.delta.y);

        if (swipeInput.magnitude > _swipeSensitivity)
        {
            DefineTurn(ref swipeInput);
            bool lift = ((int)_lastDirection - (int)_newDirection) % 2 == 1; // 90 angle rotation

            if (_lastDirection != _newDirection)
            {
                _lastDirection = _newDirection;
                GravityChanged?.Invoke(_newDirection, lift);
            }
        }
    }


    private void DefineTurn(ref Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            _newDirection = delta.x < 0 ? GravityDirection.Left : GravityDirection.Right;
        }

        else
        {
            _newDirection = delta.y < 0 ? GravityDirection.Down : GravityDirection.Up;
        }

        _newDirection = (GravityDirection)(((int)_newDirection + (int)_lastDirection) % _numOfDirections);        
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}
