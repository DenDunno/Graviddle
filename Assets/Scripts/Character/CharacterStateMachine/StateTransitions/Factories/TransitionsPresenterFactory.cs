using System.Collections.Generic;


public abstract class TransitionsPresenterFactory
{
    protected CharacterStatesPresenter States;
    

    public void SetStates(CharacterStatesPresenter states)
    {
        States = states;
    }


    public TransitionsPresenter Create()
    {
        var transitionPresenter = new TransitionsPresenter();

        foreach (Transition transition in GetTransitions())
        {
            transitionPresenter.AddTransition(transition);
        }

        return transitionPresenter;
    }


    protected abstract List<Transition> GetTransitions();
}