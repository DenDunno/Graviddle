using UnityEngine;

public class UIState : MonoBehaviour
{
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;

    public void Activate()
    {
        _uiStatesSwitcher.ActivateState(this);
    }
}