using System;


public class TransitionByCondition : Transition
{
    private readonly Func<bool> _transitionCondition;


    public TransitionByCondition(CharacterState stateFrom, CharacterState stateTo, Func<bool> transitionCondition) : base(stateFrom, stateTo)
    {
        _transitionCondition = transitionCondition;
    }


    protected override bool OnCheckTransition()
    {
        return _transitionCondition();
    }
}
