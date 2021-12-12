using UnityEngine;


public class ParallaxSwitcher : MonoBehaviour
{
    private GameParallax[] _parallaxes;


    private void Start()
    {
        _parallaxes = GetComponentsInChildren<GameParallax>();
    }


    public void ActivateParallax()
    {
        ToggleParallax(true);
    }


    public void DeactivateParallax()
    {
        ToggleParallax(false);
    }


    private void ToggleParallax(bool activate)
    {
        _parallaxes.ForEach(parallax => parallax.enabled = activate);
    }
}