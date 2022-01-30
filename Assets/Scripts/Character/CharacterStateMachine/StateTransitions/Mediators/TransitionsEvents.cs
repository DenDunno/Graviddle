using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[Serializable]
public class TransitionsEvents
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button[] _boxGrabbingButtons;
    [SerializeField] private CharacterEvents _characterEvents;

    public UnityEvent Restart => _restartButton.onClick;
    public UnityEvent ObstacleEntered => _characterEvents.ObstacleEntered;
    public UnityEvent FinishEntered => _characterEvents.FinishEntered;
    public UnityEvent CharacterResurrected => _characterEvents.CharacterRestarted;
    public IEnumerable<UnityEvent> BoxGrabbed => _boxGrabbingButtons.Select(grabButton => grabButton.onClick);
}