using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class CharacterToPortalPulling
{
    [SerializeField] private Transform _finishPortal;
    [SerializeField] private Character _character;
    private Vector2 _velocity;
    private const float _duration = 3f;
    private const float _smoothingTime = 0.5f;
    private const float _offset = 0.6f;


    public IEnumerator PullCharacterToPortal()
    {
        float clock = Time.time;
        Transform character = _character.transform;
        
        while (clock + _duration > Time.time)
        {
            Vector2 targetPosition = _finishPortal.position - _finishPortal.transform.up * _offset;
            character.position = Vector2.SmoothDamp(character.position, targetPosition, ref _velocity, _smoothingTime);

            yield return null;
        }
    }
}