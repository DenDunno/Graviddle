using UnityEngine;


public class EditorUISwitcher : MonoBehaviour
{
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher = null;


    private void Start()
    {
        #if  UNITY_EDITOR
        _uiStatesSwitcher.gameObject.SetActive(true);
        #endif
    }
}
