using UnityEngine;
using UnityEngine.EventSystems;



public class Touch : MoveСontrolType
{   
    private float _screen;
    private void Start()
    {
        _screen = Screen.width;
    }

    private void Update()
    {
        int i = 0;
        Movement = Move.STOP;

        while (i < Input.touchCount && FinishPortal.IsPLaying)
        {
            if (Input.GetTouch(i).position.x > _screen / 2)
                Movement = Move.RIGHT;

            else
                Movement = Move.LEFT;

            ++i;
        }
    }
}
