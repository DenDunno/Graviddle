using UnityEngine;
using UnityEngine.AddressableAssets;


public class AppStartup : MonoBehaviour
{
    [SerializeField] private BackgroundMusicSpawner _backgroundMusicSpawner;
    [SerializeField] private AdvertisementStartup _advertisementStartup;
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
        _backgroundMusicSpawner.Init();
        _advertisementStartup.Init();
    }
}
