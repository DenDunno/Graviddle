using UnityEngine;
using Zenject;


public class TutorialInfo : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;


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
        gameObject.SetActive(false);
    }
}
