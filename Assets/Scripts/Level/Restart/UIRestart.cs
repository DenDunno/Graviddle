using UnityEngine;
using Zenject;


[RequireComponent(typeof(UIStatesSwitcher))]
public class UIRestart : MonoBehaviour, IAfterRestartComponent
{
    [SerializeField] private UIState _initialUIState;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    private UIStatesSwitcher _uiStatesSwitcher;


    private void Start()
    {
        _uiStatesSwitcher = GetComponent<UIStatesSwitcher>();
    }


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
        _uiStatesSwitcher.DeactivateStates();
    }


    void IAfterRestartComponent.Restart()
    {
        _initialUIState.ActivateState();
    }
}