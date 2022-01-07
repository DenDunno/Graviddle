using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[Serializable]
public class TransitionsEvents
{
    [SerializeField] private Button _restartButton = null;
    [SerializeField] private CollisionEvents _collisionEvents = null;

    public UnityEvent Restart => _restartButton.onClick;
    public UnityEvent ObstacleEntered => _collisionEvents.ObstacleEntered;
    public UnityEvent FinishEntered => _collisionEvents.FinishEntered;
}