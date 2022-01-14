using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[Serializable]
public class TransitionsEvents
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private CollisionEvents _collisionEvents;

    public UnityEvent Restart => _restartButton.onClick;
    public UnityEvent ObstacleEntered => _collisionEvents.ObstacleEntered;
    public UnityEvent FinishEntered => _collisionEvents.FinishEntered;
}