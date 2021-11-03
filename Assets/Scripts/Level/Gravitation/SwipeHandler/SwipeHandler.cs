using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandler : MonoBehaviour, IBeginDragHandler , IRestartableComponent
{
    public event Action<GravityDirection> GravityChanged;

    [SerializeField] private CharacterMovement _characterMovement = null;
    [SerializeField] private bool _isCameraRotating = true;

    private readonly int _numOfDirections = 4;
    private readonly float _swipeSensitivity = 1.0f;
    private GravityDirection _newDirection;
    private GravityDirection _lastDirection;


    public void OnBeginDrag(PointerEventData eventData)
    {
        var swipeInput = new Vector2(eventData.delta.x, eventData.delta.y);

        if (swipeInput.magnitude > _swipeSensitivity && _characterMovement.MoveDirection == Vector2.zero)
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

        if (_isCameraRotating)
        {
            _newDirection = (GravityDirection)(((int)_newDirection + (int)_lastDirection) % _numOfDirections);
        }
    }


    private void TryChangeGravity()
    {
        if (_lastDirection != _newDirection)
        {
            _lastDirection = _newDirection;
            GravityChanged?.Invoke(_newDirection);
        }
    }
    

    void IRestartableComponent.Restart()
    {
        enabled = true;
        _newDirection = GravityDirection.Down;

        TryChangeGravity();
    }
}
