using UnityEngine;


public class LaserWithEvent : MonoBehaviour
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
        StartCoroutine(_laserSwitcher.ToggleLaser(isButtonPressed == false));
    }
}
