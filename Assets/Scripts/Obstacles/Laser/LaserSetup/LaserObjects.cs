using System;
using UnityEngine;


[Serializable]
public class LaserHitObjectsPositions
{
    [SerializeField] private LaserLightBulb _laserLightBulb = null;
    [SerializeField] private ParticleSystem _hitEffect = null;
    [SerializeField] private bool _isLightBulbInRight = true;

    private readonly Vector2 _hitEffectOffset = new Vector2(0.05f, -0.05f);
    private readonly Vector2 _lightBulbOffset = new Vector2(0, -0.25f);
    private readonly float _leftLightBulbSideOffset = -0.798f;
    private readonly float _rightLightBulbSideOffset = 0.902f;


    public void SetupPositions(Vector2 hitPoint)
    {
        Vector2 lightBulbOffset = _lightBulbOffset;
        lightBulbOffset.x = _isLightBulbInRight ? _rightLightBulbSideOffset : _leftLightBulbSideOffset;

        _laserLightBulb.transform.SetPositionWithLocalOffset(hitPoint, lightBulbOffset);
        _hitEffect.transform.SetPositionWithLocalOffset(hitPoint, _hitEffectOffset);
    }
}