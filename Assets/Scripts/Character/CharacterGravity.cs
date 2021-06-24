using System.Collections.Generic;
using UnityEngine;


public class CharacterGravity : MonoBehaviour
{
    private readonly List<CharacterGravityData> _gravityData = new List<CharacterGravityData>()
    {
        new CharacterGravityData(new Vector2(0  , -1) , 0),
        new CharacterGravityData(new Vector2(1  ,  0) , 90),
        new CharacterGravityData(new Vector2(0  ,  1) , 180),
        new CharacterGravityData(new Vector2(-1 ,  0) , 270)
    };

    private readonly float _rotationSpeed = 5f;
    private Quaternion _targetRotation;

    [SerializeField] private SwipeHandler _swipeHandler;
    

    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        var gravityData = _gravityData[(int)gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
        _targetRotation = gravityData.CharacterRotation;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }
}





