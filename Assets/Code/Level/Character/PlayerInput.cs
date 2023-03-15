using System;
using UnityEngine;

[Serializable]
public class PlayerInput
{
    [SerializeField] private InputButton _leftButton;
    [SerializeField] private InputButton _rightButton;

    public Vector2 Input => new((int)State, 0);

    public MovementState State
    {
        get
        {
            if (_leftButton.IsTouching)
                return MovementState.Left;

            if (_rightButton.IsTouching)
                return MovementState.Right;

            return MovementState.Stop;
        }
    }
}