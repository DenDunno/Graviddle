using UnityEngine;


public class LevelUIEnabling : MonoBehaviour
{
    // enable UI when level was loaded
    private void OnDestroy()
    {
        var uiStatesSwitcher = FindObjectOfType<UIStatesSwitcher>(true);
        uiStatesSwitcher.gameObject.SetActive(true);
    }
}