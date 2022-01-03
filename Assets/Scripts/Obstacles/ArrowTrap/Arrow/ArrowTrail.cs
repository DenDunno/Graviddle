using System;
using UnityEngine;


[Serializable]
public class ArrowTrail
{
    [SerializeField] private TrailRenderer _trail = null;


    public void ActivateTrail()
    {
        ToggleTrail(true);
    }


    public void DeactivateTrail()
    {
        ToggleTrail(false);
    }


    private void ToggleTrail(bool activateTrail)
    {
        _trail.enabled = activateTrail;
    }
}