using System;
using UnityEngine;


[Serializable]
public class PortalView
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Init()
    {
        _spriteRenderer.materials = _materials;
    }
}