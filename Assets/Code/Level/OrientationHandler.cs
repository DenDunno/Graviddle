using UnityEngine;

public class OrientationHandler
{
    public readonly float Sensitivity;
    private readonly int _numOfDirections = 4;
    private GravityDirection _lastDirection;

    public OrientationHandler(float sensitivity)
    {
        Sensitivity = sensitivity;
    }

    public GravityDirection LocalDirection { get; private set; }
    public GravityDirection GlobalDirection => (GravityDirection)(((int)LocalDirection + (int)_lastDirection) % _numOfDirections);

    public bool TryChangeDirection(Vector2 delta)
    {
        if (delta.magnitude > Sensitivity)
        {
            _lastDirection = GlobalDirection;
            
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                LocalDirection = delta.x < 0 ? GravityDirection.Left : GravityDirection.Right;
            }

            else
            {
                LocalDirection = delta.y < 0 ? GravityDirection.Down : GravityDirection.Up;
            }
        }
        
        return _lastDirection != GlobalDirection;
    }

    public void Reset()
    {
        LocalDirection = GravityDirection.Down;
    }
}