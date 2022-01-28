using System.Collections.Generic;


public abstract class TransitionsPresenterFactory
{
    protected CharacterStatesPresenter States;
    

    public void SetStates(CharacterStatesPresenter states)
    {
        States = states;
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