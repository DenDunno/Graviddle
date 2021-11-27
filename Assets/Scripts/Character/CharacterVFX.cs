using UnityEngine;
using Zenject;


public class CharacterVFX : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _states = null;
    [Inject] private readonly TransitionEvent _transitionEvent = null;
    [SerializeField] private ParticleSystem _dust = null;


    private void OnEnable()
    {
        _transitionEvent.Subscribe(_states.FallState , _states.IdleState , OnCharacterFell);
    }


    private void OnDisable()
    {
        _transitionEvent.UnSubscribe(OnCharacterFell);
    }


    private void OnCharacterFell()
    {
        _dust.Play();
    }
}
