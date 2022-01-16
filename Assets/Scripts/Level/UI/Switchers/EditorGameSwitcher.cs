using UnityEngine;


public class EditorGameSwitcher : MonoBehaviour
{
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    [SerializeField] private CharacterInputButton[] _inputButtons;
    

    private void Start()
    {
        #if  UNITY_EDITOR
        _uiStatesSwitcher.gameObject.SetActive(true);
        _inputButtons.ForEach(inputButton => inputButton.gameObject.SetActive(false));
        #endif
    }
}
