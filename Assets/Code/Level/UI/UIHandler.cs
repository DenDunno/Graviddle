
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
        _ui.DisableAll();
    }

    private async void OnWon()
    {
        await _ui.Show<WinPanel>();
    }

    async void IAfterRestart.Restart()
    {
        await _ui.Show<GameplayPanel>();
    }
}