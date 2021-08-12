using UnityEngine;


public class UIRestart : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private UISwitcher _uiSwitcher = null;
    [SerializeField] private UIState _initialUIState = null;


    private void OnEnable()
    {
        CharacterStates.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        CharacterStates.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        _uiSwitcher.DeactivateAllStates();
    }


    void IAfterRestartComponent.Restart()
    {
        _initialUIState.ActivateState();
    }
}