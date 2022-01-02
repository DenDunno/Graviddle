using UnityEngine;
using System;


[Serializable]
public class LaserDistance
{
    [SerializeField] private LineRenderer _lineRenderer = null;
    [SerializeField] private BoxCollider2D _boxCollider = null;
    [SerializeField] private ParticleSystem _hitEffect = null;
    [SerializeField] private LaserLightBulb _laserLightBulb = null;


    public void Setup(Vector2 startPosition, Vector2 hitPoint)
    {
        SetupLine(startPosition, hitPoint);
        SetupCollider(Vector2.Distance(startPosition, hitPoint));
        _hitEffect.transform.SetPositionWithLocalOffset(hitPoint, new Vector2(0.05f, -0.05f));
        _laserLightBulb.transform.SetPositionWithLocalOffset(hitPoint, new Vector2(0.902f, -0.25f));
    }


    private void SetupLine(Vector2 startPosition, Vector2 hitPoint)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, hitPoint);
    }


    private void SetupCollider(float laserDistance)
    {
        float colliderOffset = 0.5f * laserDistance;

        _boxCollider.size = new Vector2(_boxCollider.size.x, laserDistance);
        _boxCollider.offset = new Vector2(_boxCollider.offset.x, colliderOffset);
    }
}