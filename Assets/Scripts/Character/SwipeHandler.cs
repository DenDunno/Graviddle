using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public int NumOfRotations { get; private set; }
    public GravityDirection GravityDirection { get; private set; }

    private readonly List<CharacterGravityData> _gravityData = new List<CharacterGravityData>()
    {
        new CharacterGravityData(new Vector2(0  , -1) , 0),
        new CharacterGravityData(new Vector2(1  ,  0) , 90),
        new CharacterGravityData(new Vector2(0  ,  1) , 180),
        new CharacterGravityData(new Vector2(-1 ,  0) , 270)
    };

    private float _swipeSensitivity = 1.0f;


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _rotationSpeed);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 swipeInput = new Vector2(eventData.delta.x, eventData.delta.y);
        
        if (swipeInput.magnitude > _swipeSensitivity)
        {
            DefineTurn(ref swipeInput);
            ++NumOfRotations;
        }
    }


    private void DefineTurn(ref Vector2 delta)
    {
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            GravityDirection = delta.x < 0 ? GravityDirection.Left : GravityDirection.Right;
        }

        else
        {
            GravityDirection = delta.y < 0 ? GravityDirection.Down : GravityDirection.Up;
        }

        Physics2D.gravity = _gravityData[(int)GravityDirection].GravityVector;
    }


    private void ChangeGravitation()
    {

    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}
