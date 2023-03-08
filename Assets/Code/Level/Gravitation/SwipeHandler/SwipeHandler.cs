using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IRestart
{
    public bool IsActive = true;
    private readonly OrientationHandler _router = new(5);

    public event Action<GravityDirection> GravityChanged;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 swipeInput = new(eventData.delta.x, eventData.delta.y);

        if (IsActive && _router.TryChangeDirection(swipeInput))
        {
            GravityChanged?.Invoke(_router.GlobalDirection);
        }
    }

    void IRestart.Restart()
    {
        _router.Reset();
        GravityChanged?.Invoke(GravityDirection.Down);
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}