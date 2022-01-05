using System.Collections.Generic;
using UnityEngine.Events;


public class TransitionByEvent
{
    private readonly List<UnityAction> _observableEvents = new List<UnityAction>();
    public bool EventHappened { get; private set; }


    public void AddEvent(UnityAction observableEvent)
    {
        observableEvent += SetEventFlag;
        _observableEvents.Add(observableEvent);
    }


    private void SetEventFlag()
    {
        EventHappened = true;
    }


    public void Clear()
    {
        EventHappened = false;
    }


    ~TransitionByEvent()
    {
        _observableEvents.ForEach(observableEvent => observableEvent -= SetEventFlag);
    }
}