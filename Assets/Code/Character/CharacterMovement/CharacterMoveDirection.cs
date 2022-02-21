﻿using System;
using UnityEngine;


[Serializable]
public class CharacterMoveDirection : IUpdatable
{
    [SerializeField] private InputButton[] _inputButtons;
    [SerializeField] private CharacterSpriteFlipping _characterSpriteFlipping;
    private CurrentGravityData _currentGravityData;

    public Vector2 Direction { get; private set; }


    public void Init(CurrentGravityData currentGravityData)
    {
        _currentGravityData = currentGravityData;
    }
    
    
    void IUpdatable.Update()
    {
        var state = MovementState.Stop;
        
        TryRun(0, ref state, MovementState.Left);
        TryRun(1, ref state, MovementState.Right);
        
        Direction = _currentGravityData.Data.Rotation * (Vector2.right * (int) state);
    }


    private void TryRun(int buttonIndex, ref MovementState state, MovementState targetState)
    {
        if (_inputButtons[buttonIndex].IsTouching)
        {
            state = targetState;
            _characterSpriteFlipping.FlipCharacter(state);
        }
    }
}