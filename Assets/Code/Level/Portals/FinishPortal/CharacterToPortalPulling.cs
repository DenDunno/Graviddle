using System;
using DG.Tweening;
using UnityEngine;


[Serializable]
public class CharacterToPortalPulling
{
    [SerializeField] private Transform _pullingPoint;
    [SerializeField] private Character _character;
    private const float _animationDuration = 1.25f;

    public void Execute()
    {
        var gravityRotation = _character.GetComponent<GravityRotation>();
        gravityRotation.enabled = false;
        
        _character.transform.DOMove(_pullingPoint.transform.position, _animationDuration);
        _character.transform.DORotate(_pullingPoint.transform.eulerAngles, _animationDuration);
    }
}