using UnityEngine;
using Zenject;


public class WinPanel : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    [SerializeField] private UIState _uiState = null;
    [SerializeField] private WinAnimation _winAnimation = null;


    private void OnEnable()
    {
        _characterStatesPresenter.WinState.CharacterWon += OnCharacterWon;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.WinState.CharacterWon -= OnCharacterWon;
    }


    private void OnCharacterWon()
    {
        _winAnimation.ShowWinPanel();
        _uiState.ActivateState();
    }
}