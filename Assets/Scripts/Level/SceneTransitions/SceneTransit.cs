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


    public async UniTask MakeTransition(int scene)
    {
        var backstage = new Backstage(_loadingScreen, ()=> LoadScene(scene));
        
        await backstage.MakeTransition();

        Destroy(_loadingScreen.gameObject);
    }


    private async UniTask LoadScene(int scene)
    {
        await SceneManager.LoadSceneAsync(scene);
    }
}