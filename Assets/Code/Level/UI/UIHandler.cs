
public class UIHandler : ISubscriber, IAfterRestart
{
    private readonly CharacterStatesPresenter _states;
    private readonly UI _ui;

    public UIHandler(CharacterStatesPresenter states, UI ui)
    {
        _states = states;
        _ui = ui;
    }
    
    void ISubscriber.Subscribe()
    {
        _states.DieState.Entered += OnDied;
        _states.WinState.Entered += OnWon;
    }

    void ISubscriber.Unsubscribe()
    {
        _states.DieState.Entered -= OnDied;
        _states.WinState.Entered -= OnWon;
    }

    private void OnDied()
    {
        _ui.HideAll();
    }

    private void OnWon()
    {
        _ui.Show<WinPanel>();
    }

    void IAfterRestart.Restart()
    {
        _ui.Show<GameplayPanel>();
    }
}