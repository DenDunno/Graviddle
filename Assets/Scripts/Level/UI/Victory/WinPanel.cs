using UnityEngine;
using Zenject;

[RequireComponent(typeof(WinAnimation))]
[RequireComponent(typeof(UIState))]
public class WinPanel : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private UIState _uiState;
    private WinAnimation _winAnimation;


    private void Start()
    {
        _uiState = GetComponent<UIState>();
        _winAnimation = GetComponent<WinAnimation>();
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
        _winAnimation.ShowWinPanel();
        _uiState.ActivateState();
    }
}