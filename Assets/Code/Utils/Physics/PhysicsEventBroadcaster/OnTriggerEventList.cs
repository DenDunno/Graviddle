using System;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEventList
{
    private readonly Dictionary<Type, List<IOnTriggerEvent>> _onTriggerEvents = new();
        
    public void RegisterEvent<T>(Action<T> callBack) where T : MonoBehaviour 
    {
        Type type = typeof(T);
        
        if (_onTriggerEvents.ContainsKey(type) == false)
        {
            _onTriggerEvents[type] = new List<IOnTriggerEvent>();
        }
        
        _onTriggerEvents[type].Add(new OnTriggerEvent<T>(callBack));
    }
    
    public void UnRegisterEvent<T>(Action<T> callBack) where T : MonoBehaviour
    {
        List<IOnTriggerEvent> callbacks = _onTriggerEvents[typeof(T)];
        
        for (int i = 0; i < callbacks.Count; ++i)
        {
            OnTriggerEvent<T> triggerEvent = (OnTriggerEvent<T>)callbacks[i];
        
            if (triggerEvent.Callback == callBack)
            {
                callbacks.RemoveAt(i);
                break;
            }
        }
    }
    
    public void TryInvokeEvents(Collider2D collider2d)
    {
        foreach (Type type in _onTriggerEvents.Keys)
        {
            if (collider2d.TryGetComponent(type, out Component component))
            {
                List<IOnTriggerEvent> callbacks = _onTriggerEvents[type];
                
                for (int i = 0; i < callbacks.Count; ++i)
                {
                    callbacks[i].Invoke(component);
                }                
            }
        }
    }
}