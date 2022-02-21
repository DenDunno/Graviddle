using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Object = UnityEngine.Object;


[Serializable]
public class AdvertisementStartup
{
    [SerializeField] private LevelTransitionAdvertisementCounter _transitionAdvertisementCounter;
    private const bool _testMode = false;


    public void Init()
    {
        string gameId;
        
        #if UNITY_ANDROID
        gameId = "4621045";
        #else
        gameId = "4621044";
        #endif
        
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, _testMode);
            Object.Instantiate(_transitionAdvertisementCounter);
        }
    }
}