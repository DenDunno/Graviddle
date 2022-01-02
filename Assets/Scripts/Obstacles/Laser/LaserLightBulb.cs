using UnityEngine;


public class LaserLightBulb : MonoBehaviour
{
    [SerializeField] private LaserSwitcher _laserSwitcher = null;
    [SerializeField] private Animator _animator = null;
    private readonly string _switchingOnAnimationName = "SwitchingOn";
    private readonly string _switchingOffAnimationName = "SwitchingOff";


    private void OnEnable()
    {
        _laserSwitcher.LaserToggled += ToggleLightBulb;
    }


    private void OnDisable()
    {
        _laserSwitcher.LaserToggled -= ToggleLightBulb;
    }


    private void ToggleLightBulb(bool activate)
    {
        _animator.Play(activate ? _switchingOnAnimationName : _switchingOffAnimationName);
    }
}