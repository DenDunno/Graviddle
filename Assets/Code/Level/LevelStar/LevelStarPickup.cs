using System;
using UnityEngine;

public class LevelStarPickup : ISubscriber, IRestart
{
    private readonly PhysicsEventBroadcaster _physicsEvent;
    private readonly StarPickupFeedback _feedback;
    private readonly Action _onStarCollected;
    private readonly Transform _transform;

    public LevelStarPickup(PhysicsEventBroadcaster physicsEvent, StarPickupFeedback feedback, Transform transform, Action onStarCollected)
    {
        _onStarCollected = onStarCollected;
        _physicsEvent = physicsEvent;
        _transform = transform;
        _feedback = feedback;
    }

    public void Subscribe()
    {
        _physicsEvent.Entered += OnEntered;
    }

    public void Unsubscribe()
    {
        _physicsEvent.Entered -= OnEntered;
    }

    private void OnEntered(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            _transform.gameObject.SetActive(false);
            
            _feedback.Play(_transform.position);
            
            _onStarCollected?.Invoke();
        }
    }

    void IRestart.Restart()
    {
        _transform.gameObject.SetActive(true);
    }
}