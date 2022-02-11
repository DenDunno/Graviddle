using UnityEngine;


public class UIRestart : MonoBehaviour, IAfterRestart
{
    [SerializeField] private UIState _initialUIState;
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    private DieState _characterDieState;

    
    public void Init(DieState dieState)
    {
        _characterDieState = dieState;
    }


    private void OnEnable()
    {
        _characterDieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterDieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        _uiStatesSwitcher.DeactivateStates();
    }


    void IAfterRestart.Restart()
    {
        _initialUIState.Activate();
    }
}