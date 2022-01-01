using System.Collections;
using DG.Tweening;
using UnityEngine;
using System;


[Serializable]
public class LaserSwitcher
{
    [SerializeField] private LaserDistortion _laserDistortion = null;
    private LaserData _laserData = new LaserData();


    public void Init(bool startOnAwake)
    {
        _laserDistortion.Init();
        _laserDistortion.SetDistortion(_laserData.GetNoiseDistortion(startOnAwake));
    }


    public IEnumerator ToggleLaser(bool activateLaser)
    {
        float targetDistortion = _laserData.GetNoiseDistortion(activateLaser);
        float startDistortion = _laserData.GetNoiseDistortion(activateLaser == false);
        float duration = _laserData.GetDistortionSpeed(activateLaser);

        yield return DOTween.To(x => _laserDistortion.SetDistortion(x), startDistortion, targetDistortion, duration);
    }
}