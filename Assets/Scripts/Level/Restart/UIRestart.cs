using UnityEngine;
using Zenject;


[RequireComponent(typeof(UISwitcher))]
public class UIRestart : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private UIState _initialUIState = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private UISwitcher _uiSwitcher = null;


    private void Start()
    {
        _uiSwitcher = GetComponent<UISwitcher>();
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
        _uiSwitcher.DeactivateStates();
    }


    void IAfterRestartComponent.Restart()
    {
        _initialUIState.ActivateState();
    }
}