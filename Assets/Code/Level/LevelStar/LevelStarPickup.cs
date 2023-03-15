using System;
using UnityEngine;

public class LevelStarPickup : ISubscriber, IRestart
{
    private readonly PhysicsEventBroadcaster _physicsEvent;
    private readonly StarPickupFeedback _feedback;
    private readonly Action _onStarCollected;
    private readonly Transform _starTransform;

    public LevelStarPickup(PhysicsEventBroadcaster physicsEvent, StarPickupFeedback feedback, Transform starTransform, Action onStarCollected)
    {
        _onStarCollected = onStarCollected;
        _physicsEvent = physicsEvent;
        _starTransform = starTransform;
        _feedback = feedback;
    }

    void ISubscriber.Subscribe()
    {
        _physicsEvent.RegisterOnTriggerEnter<Character>(OnCharacterEntered);
    }

    void ISubscriber.Unsubscribe()
    {
        _physicsEvent.UnRegisterOnTriggerEnter<Character>(OnCharacterEntered);
    }

    private void OnCharacterEntered(Character character)
    {
        _starTransform.gameObject.SetActive(false);
            
        _feedback.Play(_starTransform.position);
            
        _onStarCollected?.Invoke();
    }

    void IRestart.Restart()
    {
        _starTransform.gameObject.SetActive(true);
    }
}