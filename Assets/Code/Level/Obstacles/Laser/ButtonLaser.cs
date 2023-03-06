using UnityEngine;

public class ButtonLaser : MonoBehaviour
{
    [SerializeField] private LaserSwitcher _laserSwitcher;
    [SerializeField] private ButtonPressing _buttonPressing;
    
    private void Start()
    {
        _laserSwitcher.Init(true);
    }
    
    private void OnEnable()
    {
        _buttonPressing.Toggled += ToggleLaser;
    }
    
    private void OnDisable()
    {
        _buttonPressing.Toggled -= ToggleLaser;
    }

    private void ToggleLaser(bool isButtonPressed)
    {
        StopAllCoroutines();
        _laserSwitcher.StopAnimation();
        StartCoroutine(_laserSwitcher.ToggleLaser(isButtonPressed == false));
    }
}
