using UnityEngine;


public class GravityDirectionReader
{
    private const int _numOfDirections = 4;
    private const float _swipeSensitivity = 150.0f;
    private GravityDirection _direction;
    
    
    public GravityDirection ReadNewDirection()
    {
        Vector2 delta = InputExtensions.GetTouchDelta();
        var newDirection = GravityDirection.None;
        Debug.Log(delta);
        if (delta.magnitude > _swipeSensitivity)
        { 
            DefineTurn(ref delta, out newDirection);
            _direction = newDirection;
        }

        return newDirection;
    }
    
    
    private void DefineTurn(ref Vector2 delta, out GravityDirection newDirection)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            newDirection = delta.x < 0 ? GravityDirection.Left : GravityDirection.Right;
        }
    
        else
        {
            newDirection = delta.y < 0 ? GravityDirection.Down : GravityDirection.Up;
        }

        newDirection = AdjustDirectionToLocalSpace(newDirection);
    }


    private GravityDirection AdjustDirectionToLocalSpace(GravityDirection swipeDirection)
    {
        return (GravityDirection)(((int)swipeDirection + (int) _direction) % _numOfDirections);
    }
}