using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IRestart
{
    [SerializeField] private bool _isActive = true;
    private const int _numOfDirections = 4;
    private const float _swipeSensitivity = 1.0f;
    private GravityDirection _newDirection;
    private GravityDirection _lastDirection;

    public event Action<GravityDirection> GravityChanged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 swipeInput = new(eventData.delta.x, eventData.delta.y);

        if (swipeInput.magnitude > _swipeSensitivity && _isActive)
        {
            DefineTurn(ref swipeInput);
            TryChangeGravity();
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

    private void TryChangeGravity()
    {
        if (_lastDirection != _newDirection)
        {
            _lastDirection = _newDirection;
            GravityChanged?.Invoke(_newDirection);
        }
    }
    
    void IRestart.Restart()
    {
        _newDirection = GravityDirection.Down;

        TryChangeGravity();
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}