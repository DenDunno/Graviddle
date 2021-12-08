using UnityEngine;
using Zenject;


public class CharacterVFX : MonoBehaviour
{
    [Inject] private readonly TransitionsPresenter _transitionsPresenter = null;
    [Inject] private readonly CharacterStatesPresenter _states = null;
    [SerializeField] private ParticleSystem _dust = null;
    private Transition _transition;


    private void Awake()
    {
        _transition = _transitionsPresenter.GetTransition(_states.FallState, _states.IdleState);
    }
    

    private void OnEnable()
    {
        _transition.TransitionHappened += OnCharacterFell;
    }


    private void OnDisable()
    {
        _transition.TransitionHappened -= OnCharacterFell;
    }


    private void OnCharacterFell()
    {
        _dust.Play();
    }
}