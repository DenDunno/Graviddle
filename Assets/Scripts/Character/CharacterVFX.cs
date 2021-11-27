using UnityEngine;
using Zenject;


public class CharacterVFX : MonoBehaviour
{
    [Inject] private readonly TransitionsPresenter _transitionsPresenter = null;
    [Inject] private readonly CharacterStatesPresenter _states = null;
    private Transition _fallToIdleTransition;


    private void OnEnable()
    {
        _fallToIdleTransition ??= _transitionsPresenter.GetTransition(_states.FallState, _states.IdleState);

        _fallToIdleTransition.TransitionHappened += OnCharacterFell;
    }


    private void OnDisable()
    {
        _fallToIdleTransition.TransitionHappened -= OnCharacterFell;
    }


    private void OnCharacterFell()
    {
        Debug.Log("Fell");
    }
}