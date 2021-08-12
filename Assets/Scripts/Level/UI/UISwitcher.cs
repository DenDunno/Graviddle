using UnityEngine;


public class UISwitcher : MonoBehaviour
{
    [SerializeField] private UIState[] _allUIStates = null;
    

    public void ActivateState(UIState uiStateToBeActivated)
    {
        uiStateToBeActivated.gameObject.SetActive(true);

        foreach (UIState uiState in _allUIStates)
        {
            if (uiState != uiStateToBeActivated)
            {
                uiState.gameObject.SetActive(false);
            }
        }
    }


    public void DeactivateAllStates()
    {
        foreach (UIState uiState in _allUIStates)
        {
            uiState.gameObject.SetActive(false);
        }
    }
}
