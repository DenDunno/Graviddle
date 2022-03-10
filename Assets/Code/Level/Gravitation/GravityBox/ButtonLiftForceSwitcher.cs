using UnityEngine;


public class ButtonLiftForceSwitcher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _buttonRigidbody;
    [SerializeField] private ButtonLiftForce _buttonForce;
    [SerializeField] private ButtonPressing _buttonPressing;


    private void OnEnable()
    {
        _buttonPressing.Toggled += OnButtonToggled;
    }
    
    
    private void OnDisable()
    {
        _buttonPressing.Toggled -= OnButtonToggled;
    }

    
    private void OnButtonToggled(bool isButtonTurnedOn)
    {
        _buttonRigidbody.velocity = Vector2.zero;
        _buttonForce.enabled = isButtonTurnedOn;
    }
}