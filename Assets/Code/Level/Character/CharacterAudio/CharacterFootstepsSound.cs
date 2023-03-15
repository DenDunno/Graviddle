using System;
using UnityEngine;

[Serializable]
public class CharacterFootstepsSound : ISubscriber
{
    [SerializeField] private AnimationEvent _animationEvent;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip[] _clips;
    
    void ISubscriber.Subscribe()
    {
        _animationEvent.Invoked += OnCharacterStepped;
    }

    void ISubscriber.Unsubscribe()
    {
        _animationEvent.Invoked -= OnCharacterStepped;
    }

    private void OnCharacterStepped()
    {
        AudioClip randomClip = _clips.GetRandomElement();
        _source.clip = randomClip;
        _source.Play();
    }
}