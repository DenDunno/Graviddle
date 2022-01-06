using System.Linq;


public class TransitionCheck
{
    private readonly TransitionsPresenter[] _transitionsPresenters;


    public TransitionCheck(TransitionsPresenter[] transitionsPresenters)
    {
        _transitionsPresenters = transitionsPresenters;
    }
    

    public TransitionResult Transit(CharacterState currentState)
    {
        return _transitionsPresenters.Select(presenter => presenter.Transit(currentState))
                                     .FirstOrDefault(result => result.TransitionHappened);
    }
}