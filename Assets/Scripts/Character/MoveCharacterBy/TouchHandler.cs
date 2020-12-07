using UnityEngine;
using UnityEngine.EventSystems;



public class TouchHandler : MoveСontrolType
{   
    private float _screen;
    private GravityChangeType _characterGravitaion;

    private void Start()
    {
        _screen = Screen.width;
        _characterGravitaion = GetComponent<GravityChangeType>();

        ControlButton[] buttons = GetComponentsInChildren<ControlButton>(); // удаляем ненужные кнопки
        foreach (var button in buttons)
            Destroy(button.gameObject);
    }

    private void Update()
    {
        Movement = Move.STOP;

        if (Input.touchCount > 0 && FinishPortal.IsPLaying)
        {
            Touch touch = Input.GetTouch(0);
            bool permitToRun = _characterGravitaion.CheckTouch(touch);

            if (permitToRun)
            {
                Movement = touch.position.x > _screen / 2 ? Move.RIGHT : Move.LEFT;
            }
        }
    }
}
