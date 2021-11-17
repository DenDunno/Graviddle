using UnityEngine;


public class UIStatesSwitcher : MonoBehaviour
{
    private UIState[] _allUIStates = null;


    private void Start()
    {
        _allUIStates = GetComponentsInChildren<UIState>(true);
    }


    public void ActivateState(UIState uiStateToBeActivated)
    {
        DeactivateStates();

        uiStateToBeActivated.gameObject.SetActive(true);
    }


    public void DeactivateStates()
    {
        foreach (UIState uiState in _allUIStates)
        {
            uiState.gameObject.SetActive(false);
        }
    }
}
