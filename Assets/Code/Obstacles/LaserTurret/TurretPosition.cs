using UnityEngine;

public class TurretPosition : IUpdate
{
    private readonly Transform _turret;
    private readonly Transform _anchor;

    public TurretPosition(Transform turret, Transform anchor)
    {
        _turret = turret;
        _anchor = anchor;
    }

    void IUpdate.Update()
    {
        _turret.position = _anchor.position;
    }
}