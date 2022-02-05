using UnityEngine;
using UnityEngine.AddressableAssets;


public class AppStartup : MonoBehaviour
{
    private void Start()
    {
        Addressables.InitializeAsync();
    }
}
