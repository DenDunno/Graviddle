using UnityEngine;
using System;


[Serializable]
public class LaserLine
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private bool _isLongLine;
    private const float _hitPointLineOffset = 0.3f;
    

    public void SetupLineDistance(Vector2 startPosition, Vector2 hitPoint)
    {
        if (_isLongLine)
        {
            Vector2 direction = (hitPoint - startPosition).normalized;
            hitPoint += direction * _hitPointLineOffset;
        }

        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, hitPoint);
    }
}