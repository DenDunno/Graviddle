using System.Collections;
using UnityEngine;


public class Laser : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private float _startWaitTime = 0f;
    [SerializeField] private float _workTime = 3f;
    [SerializeField] private float _coolDownTime = 2f;
    [SerializeField] private LaserSwitcher _laserSwitcher = null;
    

    private void Start()
    {
        _laserSwitcher.Init(_startWaitTime == 0);
        StartCoroutine(LaunchLaser());
    }


    private IEnumerator LaunchLaser()
    {
        if (_startWaitTime > 0)
        {
            yield return new WaitForSeconds(_startWaitTime);
            yield return StartCoroutine(_laserSwitcher.ToggleLaser(true));
        }

        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(_workTime);
            yield return StartCoroutine(_laserSwitcher.ToggleLaser(false));

            yield return new WaitForSeconds(_coolDownTime);
            yield return StartCoroutine(_laserSwitcher.ToggleLaser(true));
        }
    }


    void IRestartableComponent.Restart()
    {
        StopAllCoroutines();
        _laserSwitcher.Restart(_startWaitTime == 0);
        StartCoroutine(LaunchLaser());
    }
}