using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[Serializable]
public class TransitionsEvents
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private CharacterEvents _characterEvents;

    public UnityEvent Restart => _restartButton.onClick;
    public UnityEvent ObstacleEntered => _characterEvents.ObstacleEntered;
    public UnityEvent FinishEntered => _characterEvents.FinishEntered;
    public UnityEvent CharacterRestarted => _characterEvents.CharacterRestarted;
}