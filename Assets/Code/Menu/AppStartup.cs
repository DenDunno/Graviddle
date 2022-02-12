using UnityEngine;
using UnityEngine.AddressableAssets;


public class AppStartup : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _backgroundMusic;
    private static bool _appWasInited;
    
    
    private void Start()
    {
        if (_appWasInited == false)
        {
            _appWasInited = true;
            Initialize();
        }
    }


    private void Initialize()
    {
        Addressables.InitializeAsync();
        Instantiate(_backgroundMusic);
    }
}
