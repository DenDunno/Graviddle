using UnityEngine;
using Zenject;


public abstract class CharacterFallingEventsHandler : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;


    private void OnEnable()
    {
        _characterStatesPresenter.FallState.CharacterFalling += OnCharacterFalling;
        _characterStatesPresenter.IdleState.CharacterGrounded += OnCharacterGrounded;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.FallState.CharacterFalling -= OnCharacterFalling;
        _characterStatesPresenter.IdleState.CharacterGrounded -= OnCharacterGrounded;
    }


    protected abstract void OnCharacterFalling();
    protected abstract void OnCharacterGrounded();
}