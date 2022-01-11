using UnityEngine;


public class UIStatesSwitcher : MonoBehaviour, IRestartableComponent
{
    private UIState[] _allUIStates;


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

    
    void IRestartableComponent.Restart()
    {
        DeactivateStates();
    }
}