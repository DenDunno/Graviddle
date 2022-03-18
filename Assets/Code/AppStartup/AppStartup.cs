using UnityEngine;
using UnityEngine.AddressableAssets;


public class AppStartup : MonoBehaviour
{
    [SerializeField] private BackgroundMusicSpawner _backgroundMusicSpawner;
    [SerializeField] private AdvertisementStartup _advertisementStartup;
    private readonly MusicVolume _musicVolume = new MusicVolume();
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
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 160;
        Addressables.InitializeAsync();
        _backgroundMusicSpawner.Init();
        _advertisementStartup.Init();
        _musicVolume.Init();
    }
}
