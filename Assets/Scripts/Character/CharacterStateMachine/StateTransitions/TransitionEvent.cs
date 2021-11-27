using System;


public class TransitionEvent
{
    private readonly TransitionsPresenter _transitionsPresenter = null;
    private Transition _transition;


    public TransitionEvent(TransitionsPresenter transitionsPresenter)
    {
        _transitionsPresenter = transitionsPresenter;
    }


    public void Subscribe(CharacterState from, CharacterState to, Action action)
    {
        _transition = _transitionsPresenter.GetTransition(from, to);

        _transition.TransitionHappened += action;
    }


    public void UnSubscribe(Action action)
    {
        _transition.TransitionHappened -= action;
    }
}