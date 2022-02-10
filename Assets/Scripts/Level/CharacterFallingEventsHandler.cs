

public abstract class CharacterFallingEventsHandler : IRestart
{
    public abstract void OnCharacterStartFalling();
    public abstract void OnCharacterEndFalling();
    
    
    void IRestart.Restart()
    {
        OnCharacterEndFalling();
    }
}