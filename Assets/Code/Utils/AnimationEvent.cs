using System;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public event Action Invoked;
    
    public void InvokeEvent()
    {
        Invoked?.Invoke();
    }
}