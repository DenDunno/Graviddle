

public class UpdateTransitions : TransitionsPresenterBase
{
    public bool TryTransit(CharacterState currentState, out CharacterState newState)
    {
        newState = currentState;

        if (TransitionsForState.ContainsKey(currentState))
        {
            foreach (Transition transition in TransitionsForState[currentState])
            {
                if (transition.CheckCondition())
                {
                    newState = transition.StateTo;
                    break;
                }
            }
        }

        return currentState != newState;
    }
}