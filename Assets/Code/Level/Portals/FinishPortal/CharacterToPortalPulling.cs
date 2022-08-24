using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class CharacterToPortalPulling
{
    [SerializeField] private Transform _pullingPoint;
    [SerializeField] private Character _character;
    private Vector2 _velocity;
    private const float _duration = 3f;
    private const float _smoothingTime = 0.5f;
    private const float _rotationSpeed = 2f;

    public IEnumerator PullCharacterToPortal()
    {
        float clock = Time.time;
        Transform character = _character.transform;
        
        while (clock + _duration > Time.time)
        {
            character.position = Vector2.SmoothDamp(character.position, _pullingPoint.position, ref _velocity, _smoothingTime);
            character.rotation = Quaternion.Lerp(character.rotation, _pullingPoint.rotation, _rotationSpeed * Time.deltaTime);

            yield return null;
        }
    }
}