using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private UIState _uiState;
    [SerializeField] private WinAnimation _winAnimation;
    private WinState _characterWinState;

    public void Init(WinState winState)
    {
        _characterWinState = winState;
    }

    private void OnEnable()
    {
        _characterWinState.CharacterWon += OnCharacterWon;
    }

    private void OnDisable()
    {
        _characterWinState.CharacterWon -= OnCharacterWon;
    }

    private void OnCharacterWon()
    {
        _winAnimation.Play();
        _uiState.Activate();
    }
}