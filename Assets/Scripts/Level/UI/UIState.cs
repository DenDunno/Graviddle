using UnityEngine;


public class UIState : MonoBehaviour
{
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;


    public void ActivateState()
    {
        _uiStatesSwitcher.ActivateState(this);
    }
}