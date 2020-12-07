using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ControlButton : MonoBehaviour , IPointerUpHandler
{
    protected ButtonsControl _buttonsControl;
    private void Start()
    {
        _buttonsControl = GetComponentInParent<ButtonsControl>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _buttonsControl.Stop();
    }
}
