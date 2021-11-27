

public class TransitionWithEvent
{
    public readonly CharacterState StateFrom;
    public readonly CharacterState StateTo;


    public TransitionWithEvent(CharacterState stateFrom, CharacterState stateTo)
    {
        StateFrom = stateFrom;
        StateTo = stateTo;
    }
}
