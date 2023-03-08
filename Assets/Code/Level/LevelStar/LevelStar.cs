using System;
using UnityEngine;

public class LevelStar : MonoBehaviourWrapper
{
    [SerializeField] private PhysicsEventBroadcaster _physics;
    public event Action StarCollected;

    public void Init(StarPickupFeedback pickupFeedback, GravityState characterGravityState)
    {
        SetDependencies(new IUnityCallback[]
        {
            new LevelStarPickup(_physics, pickupFeedback, transform, CollectStar),
            new GravityRotation(characterGravityState, transform),
        });
    }

    private void CollectStar()
    {
        StarCollected?.Invoke();
    }
}
