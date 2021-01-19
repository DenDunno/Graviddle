using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ControlButton : MonoBehaviour, IPointerUpHandler
{
    protected MovementButtons _buttonsControl;

    private void Start()
    {
        _buttonsControl = GetComponentInParent<MovementButtons>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonsControl.Stop();
    }
}