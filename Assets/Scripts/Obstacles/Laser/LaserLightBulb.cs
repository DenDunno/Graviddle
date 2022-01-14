using UnityEngine;


public class LaserLightBulb : MonoBehaviour
{
    [SerializeField] private LaserSwitcher _laserSwitcher;
    [SerializeField] private Animator _animator;
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