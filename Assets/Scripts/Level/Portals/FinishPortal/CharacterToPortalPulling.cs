using System.Collections;
using UnityEngine;


public class CharacterToPortalPulling
{
    private readonly float _duration = 3f;
    private readonly float _smoothingTime = 0.5f;
    private readonly float _offset = 0.6f;
    private readonly Transform _finishPortal;
    private readonly Transform _character;
    private Vector2 _velocity;


    public CharacterToPortalPulling(FinishPortal finishPortal, Character character)
    {
        _finishPortal = finishPortal.transform;
        _character = character.transform;
    }


    public IEnumerator PullCharacterToPortal()
    {
        float clock = Time.time;

        while (clock + _duration > Time.time)
        {
            Vector2 targetPosition = _finishPortal.position - _finishPortal.transform.up * _offset;
            _character.position = Vector2.SmoothDamp(_character.position, targetPosition, ref _velocity, _smoothingTime);

            yield return null;
        }
    }
}