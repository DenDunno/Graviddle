using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementBanner : MonoBehaviour
{
    private string _bannerId;
    
    private void Start()
    {
        #if UNITY_ANDROID
        _bannerId = "Banner_Android";
        #else
        _bannerId = "Banner_iOS";
        #endif
        
        StartCoroutine(ShowBanner());
    }

    private IEnumerator ShowBanner()
    {
        yield return new WaitUntil(Advertisement.IsReady);
        yield return new WaitUntil(()=> Advertisement.isInitialized);

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(_bannerId);
    }

    private void OnDestroy()
    {
        Advertisement.Banner.Hide();
    }
}