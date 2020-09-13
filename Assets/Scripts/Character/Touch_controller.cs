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


public class Touch_controller : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Movement Character_movement { get; private set; }
    public Swipe Swipe { get; private set; }

    private float screen;
    private float swipe_sensitivity = 1.0f;

    private Character character;


    private void Start()
    {
        screen = Screen.width;
        character = FindObjectOfType<Character>();
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
        float delta_x = eventData.delta.x;
        float delta_y = eventData.delta.y;

        if (Mathf.Abs(delta_x) + Mathf.Abs(delta_y) > 2 * swipe_sensitivity) // достаточно длинный ли свайп
        {

            if (Mathf.Abs(delta_x) > Mathf.Abs(delta_y)) // определяем, в какую сторону свайп "больше"
            {
                Swipe = delta_x < -swipe_sensitivity ? Swipe.LEFT : Swipe.RIGHT;
            }

            else
            {
                Swipe = delta_y < -swipe_sensitivity ? Swipe.DOWN : Swipe.UP;
            }

            if (character.IsAlive && character.IsGrounded) // когда персонаж летит, не происходит смена гравитации
                character.Change_gravity();
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}
