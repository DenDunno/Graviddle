using UnityEngine;


public class LightBulb : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _switcherMonoBehaviour;
    [SerializeField] private Animator _animator;
    private ISwitcher _switcher;
    private const string _switchingOnAnimationName = "SwitchingOn";
    private const string _switchingOffAnimationName = "SwitchingOff";


    private void OnValidate()
    {
        if (_switcherMonoBehaviour is ISwitcher switcher)
        {
            _switcher = switcher;
        }

        else
        {
            _switcherMonoBehaviour = null;
        }
    }
    

    private void OnEnable()
    {
        _switcher.Toggled += ToggleLightBulb;
    }


    private void OnDisable()
    {
        _switcher.Toggled -= ToggleLightBulb;
    }
    
    
    private void ToggleLightBulb(bool activate)
    {
        _animator.Play(activate ? _switchingOnAnimationName : _switchingOffAnimationName);
    }
}