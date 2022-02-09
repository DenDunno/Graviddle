using UnityEngine;


[RequireComponent(typeof(UIStatesSwitcher))]
public class UIRestart : MonoBehaviour, IAfterRestart
{
    [SerializeField] private UIState _initialUIState;
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;
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


    void IAfterRestart.Restart()
    {
        _initialUIState.ActivateState();
    }
}