using System.Linq;


public class CharacterStateTransitions
{
    private readonly TransitionPresenter[] _transitionPresenters;


    public CharacterStateTransitions(TransitionPresenter eventTransitionsPresenter, TransitionPresenter updateTransitionsPresenter)
    {
        _transitionPresenters = new[] { eventTransitionsPresenter, updateTransitionsPresenter };
    }


    public TransitionResult Transit(CharacterState currentState)
    {
        return _transitionPresenters.Select(transitionPresenter => transitionPresenter.Transit(currentState))
                                    .FirstOrDefault(result => result.TransitionHappened);
    }
}