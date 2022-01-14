using UnityEngine;
using System;


[Serializable]
public class LaserLine
{
    [SerializeField] private LineRenderer _lineRenderer;


    public void SetupLineDistance(Vector2 startPosition, Vector2 hitPoint)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, hitPoint);
    }
}