using UnityEngine;

public class ButtonLiftForce : MonoBehaviour, IRestart
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private ButtonPressing _buttonPressing;
    private bool _isLifting;
    
    private void OnEnable()
    {
        _buttonPressing.Toggled += OnButtonToggled;
    }

    private void OnDisable()
    {
        _buttonPressing.Toggled -= OnButtonToggled;
    }
    
    private void Update()
    {
        if (_isLifting)
        {
            _rigidbody.velocity += (Vector2) transform.up * (_speed * Time.deltaTime);
        }
    }

    private void ResetLiftForce(bool enableLiftForce)
    {
        _isLifting = enableLiftForce;
        _rigidbody.velocity = Vector2.zero;
    }
    
    private void OnButtonToggled(bool isButtonTurnedOn)
    {
        ResetLiftForce(isButtonTurnedOn);
    }

    void IRestart.Restart()
    {
        ResetLiftForce(false);
    }
}