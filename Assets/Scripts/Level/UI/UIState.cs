using UnityEngine;


public class UIState : MonoBehaviour
{
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher = null;


    public void ActivateState()
    {
        _uiStatesSwitcher.ActivateState(this);
    }
}