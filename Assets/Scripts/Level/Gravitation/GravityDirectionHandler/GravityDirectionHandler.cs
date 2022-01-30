using System;
using UnityEngine;


public class GravityDirectionHandler : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private bool _isActive = true;
    private readonly GravityDirectionReader _gravityDirectionReader = new GravityDirectionReader();
    private GravityDirection _direction;

    public event Action<GravityDirection> GravityChanged;


    private void Update()
    {
        GravityDirection newDirection = _gravityDirectionReader.ReadNewDirection();

        if (newDirection != GravityDirection.None && _isActive)
        {
            TryChangeGravity(newDirection);
        }
    }
    

    private void TryChangeGravity(GravityDirection newDirection)
    {
        if (_direction != newDirection)
        {
            _direction = newDirection;
            GravityChanged?.Invoke(newDirection);
        }
    }
    

    void IRestartableComponent.Restart()
    {
        TryChangeGravity(GravityDirection.Down);
    }
}