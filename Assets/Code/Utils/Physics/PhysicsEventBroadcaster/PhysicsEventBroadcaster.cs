using System;
using UnityEngine;

public class PhysicsEventBroadcaster : MonoBehaviour
{
    private readonly OnTriggerEventList _onTriggerEnter = new();
    private readonly OnTriggerEventList _onTriggerExit = new();
   
    public void RegisterOnTriggerEnter<T>(Action<T> callBack) where T : MonoBehaviour
    {
        _onTriggerEnter.RegisterEvent(callBack);
    }
    
    public void RegisterOnTriggerExit<T>(Action<T> callBack) where T : MonoBehaviour
    {
        _onTriggerExit.RegisterEvent(callBack);
    }

    public void UnRegisterOnTriggerEnter<T>(Action<T> callBack) where T : MonoBehaviour
    {
        _onTriggerEnter.UnRegisterEvent(callBack);
    }
    
    public void UnRegisterOnTriggerExit<T>(Action<T> callBack) where T : MonoBehaviour
    {
        _onTriggerExit.UnRegisterEvent(callBack);
    }

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        _onTriggerEnter.TryInvokeEvents(collider2d);
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        _onTriggerExit.TryInvokeEvents(collider2d);
    }
}