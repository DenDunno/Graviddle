

using System.Collections.Generic;

public class TransitionsPresenter
{
    public static StateTransitions IdleTransitions;
    public static StateTransitions RunTransitions;
    public static StateTransitions FallTransitions;

    public TransitionsPresenter()
    {
        IdleTransitions = new StateTransitions(CharacterStates.IdleState, new List<Transition>()
        {

        });

        IdleTransitions = new StateTransitions(CharacterStates.RunState, new List<Transition>()
        {

        });

        IdleTransitions = new StateTransitions(CharacterStates.FallState, new List<Transition>()
        {

        });
    }
}
