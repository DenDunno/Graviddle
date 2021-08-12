using UnityEngine;


public class UIState : MonoBehaviour
{
    [SerializeField] private UISwitcher _uiSwitcher = null;


    public void ActivateState()
    {
        _uiSwitcher.ActivateState(this);
    }
}