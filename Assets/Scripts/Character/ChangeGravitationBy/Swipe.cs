using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Swipe : GravityChangeType, IBeginDragHandler, IDragHandler
{
    private float _swipeSensitivity = 1.0f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        float delta_x = eventData.delta.x;
        float delta_y = eventData.delta.y;

        if (Mathf.Abs(delta_x) + Mathf.Abs(delta_y) > 2 * _swipeSensitivity) // достаточно длинный ли свайп
        {

            if (Mathf.Abs(delta_x) > Mathf.Abs(delta_y)) // определяем, в какую сторону свайп "больше"
            {
                _turn = delta_x < -_swipeSensitivity ? Turn.LEFT : Turn.RIGHT;
            }

            else
            {
                _turn = delta_y < -_swipeSensitivity ? Turn.DOWN : Turn.UP;
            }

            if (Character.IsAlive && Character.IsGrounded) // когда персонаж летит, не происходит смена гравитации
            {
                ChangeGravitation(_turn);
            }

        }
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
}





