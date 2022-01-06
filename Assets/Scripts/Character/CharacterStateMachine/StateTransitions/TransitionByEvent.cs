using System.Collections.Generic;
using UnityEngine.Events;


public class TransitionByEvent : Transition
{
    private readonly List<UnityAction> _observableEvents = new List<UnityAction>();
    public bool EventHappened { get; private set; }


    public TransitionByEvent(CharacterState stateFrom, CharacterState stateTo) : base(stateFrom, stateTo)
    {
    }


    ~TransitionByEvent()
    {
        _observableEvents.ForEach(observableEvent => observableEvent -= SetEventFlag);
    }


    public void AddEvent(UnityAction observableEvent)
    {
        observableEvent += SetEventFlag;
        _observableEvents.Add(observableEvent);
    }


    private void SetEventFlag() => EventHappened = true;

    public override void Clear() => EventHappened = false;

    protected override bool OnCheckTransition() => EventHappened;
}