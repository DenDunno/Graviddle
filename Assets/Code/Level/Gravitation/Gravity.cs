using UnityEngine;

public class Gravity : IRestart, IInitializable
{
    private readonly ConstantForce2D _constantForce2d;
    private readonly float _strength;

    public Gravity(ConstantForce2D constantForce2d, float strength)
    {        
        _constantForce2d = constantForce2d;
        _strength = strength;
    }

    void IInitializable.Initialize()
    {
        Restart();
    }

    public void SetDirection(Vector2 direction)
    {
        _constantForce2d.force = direction.normalized * _strength;
    }

    public void Restart()
    {
        SetDirection(Vector2.down);
    }
}