using System.Collections.Generic;


public abstract class TransitionsPresenterFactory
{
    protected CharacterStatesPresenter _states;


    public void SetStates(CharacterStatesPresenter states)
    {
        _states = states;
    }


    public TransitionPresenter Create()
    {
        var transitionPresenter = new TransitionPresenter();

        foreach (Transition transition in GetTransitions())
        {
            transitionPresenter.AddTransition(transition);
        }

        return transitionPresenter;
    }


    protected abstract List<Transition> GetTransitions();
}