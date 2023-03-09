using System;
using UnityEngine;

class OnTriggerEvent<T> : IOnTriggerEvent where T : MonoBehaviour 
{
    public readonly Action<T> Callback;

    public OnTriggerEvent(Action<T> callback)
    {
        Callback = callback;
    }
    
    public void Invoke(Component callbackObject)
    {
        Callback?.Invoke((T)callbackObject);
    }
}