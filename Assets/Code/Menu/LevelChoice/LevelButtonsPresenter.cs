
public class LevelButtonsPresenter
{
    private readonly LevelButton[] _buttons;
    private readonly UIBlocker _blocker;

    public LevelButtonsPresenter(LevelButton[] buttons, UIBlocker blocker)
    {
        _buttons = buttons;
        _blocker = blocker;
    }

    public void Init()
    {
        foreach (LevelButton levelButton in _buttons)
        {
            levelButton.Init(_blocker);
        }
    }
}