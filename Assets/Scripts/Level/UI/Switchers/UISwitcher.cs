using UnityEngine;


public class UISwitcher : MonoBehaviour
{
    [SerializeField] private UIState[] _allUIStates = null;
    

    public void ActivateState(UIState uiStateToBeActivated)
    {
        foreach (UIState uiState in _allUIStates)
        {
            uiState.gameObject.SetActive(false);
        }

        uiStateToBeActivated.gameObject.SetActive(true);
    }


    public void DeactivateAllStates()
    {
        foreach (UIState uiState in _allUIStates)
        {
            uiState.gameObject.SetActive(false);
        }
    }
}
