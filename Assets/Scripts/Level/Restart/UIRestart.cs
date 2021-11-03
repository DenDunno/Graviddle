﻿using UnityEngine;
using Zenject;


public class UIRestart : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private UISwitcher _uiSwitcher = null;
    [SerializeField] private UIState _initialUIState = null;
    [Inject] private readonly CharacterStates _characterStates = null;


    private void OnEnable()
    {
        _characterStates.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStates.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        _uiSwitcher.DeactivateAllStates();
    }


    void IAfterRestartComponent.Restart()
    {
        _initialUIState.ActivateState();
    }
}