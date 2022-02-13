using UnityEngine;


public class UIStatesSwitcher : MonoBehaviour, IAfterRestart
{
    [SerializeField] private UIState[] _allUIStates;
    [SerializeField] private UIState _initialState;
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
        DeactivateStates();
    }


    public void DeactivateStates()
    {
        foreach (UIState uiState in _allUIStates)
        {
            uiState.gameObject.SetActive(false);
        }
    }

    
    public void ActivateState(UIState uiStateToBeActivated)
    {
        DeactivateStates();

        uiStateToBeActivated.gameObject.SetActive(true);
    }


    void IAfterRestart.Restart()
    {
        _initialState.Activate();
    }
}