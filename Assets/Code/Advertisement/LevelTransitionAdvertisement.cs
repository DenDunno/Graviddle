using UnityEngine.Advertisements;


public class LevelTransitionAdvertisement
{
    private readonly string _videoId;


    public LevelTransitionAdvertisement()
    {
        #if UNITY_ANDROID
        _videoId = "Interstitial_Android";
        #else
        _videoId = "Interstitial_iOS";
        #endif
    }


    public void Show()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(_videoId);
        }
    }
}