using UnityEngine;
using Zenject;


public class UIRestart : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private UISwitcher _uiSwitcher = null;
    [SerializeField] private UIState _initialUIState = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;


    private void OnEnable()
    {
        _characterStatesPresenter.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.DieState.CharacterDied -= OnCharacterDied;
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