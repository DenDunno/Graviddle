using System;


public class UpdateTransition : Transition
{
    private readonly Func<bool> _transitionCondition;


    public UpdateTransition(CharacterState stateFrom, CharacterState stateTo, Func<bool> transitionCondition) : base(stateFrom, stateTo)
    {
        _transitionCondition = transitionCondition;
    }


    protected override bool CheckTransition(CharacterState currentState)
    {
        return _transitionCondition();
    }
}