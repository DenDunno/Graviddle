﻿using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private readonly PollingEvent _eventTransit = new();

    private void Start()
    {
        _button.onClick.AddListener(_eventTransit.Invoke);
    }
    
    public bool CheckIfPressed()
    {
        return _eventTransit.CheckIfEventHappened();
    }
}