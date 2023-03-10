using Cysharp.Threading.Tasks;

public class PausePanel : Panel
{
    private readonly TimeScale _timeScale = new();
    
    protected override UniTask OnShow()
    {
        _timeScale.FreezeGame();
        
        return base.OnShow();
    }

    protected override UniTask OnHide()
    {
        UnFreezeGame();
        
        return base.OnHide();
    }

    public void UnFreezeGame()
    {
        _timeScale.UnfreezeGame();
    }
}