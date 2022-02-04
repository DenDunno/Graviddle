using Cysharp.Threading.Tasks;
using DG.Tweening;


public class Backstage
{
    private readonly LoadingScreen _loadingScreen;
    private readonly UniTask _backstageAction;
    

    public Backstage(LoadingScreen loadingScreen, UniTask backstageAction)
    {
        _loadingScreen = loadingScreen;
        _backstageAction = backstageAction;
    }
    
    
    public async UniTask MakeTransition()
    {
        await _loadingScreen.Appear().AsyncWaitForCompletion();

        await _backstageAction;

        await _loadingScreen.Disappear().AsyncWaitForCompletion();
    }
}
