using UnityEngine;


public class ButtonForceSwitcher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _buttonRigidbody;
    [SerializeField] private ConstantForce2D _buttonForce;
    [SerializeField] private ButtonPressEvent _buttonPressEvent;


    private void OnEnable()
    {
        _buttonPressEvent.Toggled += OnButtonToggled;
    }
    
    
    private void OnDisable()
    {
        _buttonPressEvent.Toggled -= OnButtonToggled;
    }

    
    private void OnButtonToggled(bool isButtonTurnedOn)
    {
        _buttonRigidbody.velocity = Vector2.zero;
        _buttonForce.enabled = isButtonTurnedOn;
    }
}