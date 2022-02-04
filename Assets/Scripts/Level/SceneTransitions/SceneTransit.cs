using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransit : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    private async UniTask MakeTransition(int scene)
    {
        UniTask sceneLoadingTask = WaitWhileSceneLoading(scene);
        var backstage = new Backstage(_loadingScreen, sceneLoadingTask);
        
        await backstage.MakeTransition();

        Destroy(gameObject);
    }


    private async UniTask WaitWhileSceneLoading(int scene)
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(scene);
        sceneLoadingOperation.allowSceneActivation = true;
        
        await UniTask.WaitWhile(() => sceneLoadingOperation.isDone == false);        
    }
}