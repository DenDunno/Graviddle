using UnityEngine;
using Zenject;


public class WinPanel : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [SerializeField] private UIState _uiState;
    [SerializeField] private WinAnimation _winAnimation;


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
        _winAnimation.Play();
        _uiState.ActivateState();
    }
}