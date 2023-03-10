using Cysharp.Threading.Tasks;

public class LevelChoicePanel : AnimatedPanel
{
    public override UniTask Init()
    {
        LevelButton[] buttons = GetComponentsInChildren<LevelButton>();
        LevelButtonsPresenter buttonsPresenter = new(buttons, UIBlocker);
        
        buttonsPresenter.Init();

        return base.Init();
    }
}