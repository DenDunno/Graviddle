using System;
using System.Collections.Generic;
using UnityEngine;


public class CharacterCollisionEvents : MonoBehaviour
{
    private readonly Dictionary<Type, EventTransit> _collisionEventTransitions = new Dictionary<Type, EventTransit>()
    {
        {typeof(Obstacle), new EventTransit()},
        {typeof(FinishPortal), new EventTransit()},
        {typeof(Ground), new EventTransit()}
    };


    public bool CheckCollision<T>()
    {
        return _collisionEventTransitions[typeof(T)].CheckIfEventHappened();
    }
    
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        TryCollide<Obstacle>(collider2d);
        TryCollide<FinishPortal>(collider2d);
        TryCollide<Ground>(collider2d);
    }


    private void TryCollide<T>(Collider2D collider2d)
    {
        if (collider2d.GetComponent<T>() != null)
        {
            _collisionEventTransitions[typeof(T)].Invoke();
        }
    }
}