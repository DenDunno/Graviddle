using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Movement
{
    STOP,
    LEFT = -1,
    RIGHT = 1
}

public enum Swipe
{
   DOWN,
   LEFT,
   RIGHT,
   UP
}


public class Touch_controller : MonoBehaviour , IBeginDragHandler, IDragHandler
{
    public Movement Character_movement;
    public Swipe  Swipe;
    public bool IsSwipe;
    
    private float screen;
    private float swipe_sensitivity = 15.0f;


    private void Start()
    {
        screen = Screen.width;
    }


    private void Update()
    {
        int i = 0;
        Character_movement = Movement.STOP;

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screen / 2)
                Character_movement = Movement.RIGHT;

            else
                Character_movement = Movement.LEFT;

            ++i;
        }
    }
  

    public void OnBeginDrag(PointerEventData eventData) 
    {
        if (Character.IsAlive)
            IsSwipe = true;

        float delta_x = eventData.delta.x;
        float delta_y = eventData.delta.y;

        if (Mathf.Abs(delta_x) > Mathf.Abs(delta_y)) // определяем свайп
        {
            if (delta_x > swipe_sensitivity)
                Swipe = Swipe.RIGHT;
            else if (delta_x < -swipe_sensitivity)
                Swipe = Swipe.LEFT;
        }

        else
        {
            if (delta_y > swipe_sensitivity)
                Swipe = Swipe.UP;
            else if (delta_y < -swipe_sensitivity)
                Swipe = Swipe.DOWN;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
