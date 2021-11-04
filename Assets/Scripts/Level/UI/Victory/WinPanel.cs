using UnityEngine;
using Zenject;

[RequireComponent(typeof(UIState))]
public class WinPanel : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private UIState _uiState;


    private void Start()
    {
        _uiState = GetComponent<UIState>();
    }


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
        _uiState.ActivateState();
    }
}