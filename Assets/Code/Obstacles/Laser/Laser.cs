using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour, IRestart
{
    [SerializeField] private float _startWaitTime;
    [SerializeField] private float _workTime = 3f;
    [SerializeField] private float _coolDownTime = 2f;
    [SerializeField] private bool _infiniteWorking;
    [SerializeField] private bool _startOnAwake = true;
    [SerializeField] private LaserSwitcher _laserSwitcher;
    
    private void Start()
    {
        _laserSwitcher.Init(_startOnAwake);

        if (_infiniteWorking == false)
        {
            StartCoroutine(LaunchLaser());
        }
    }

    private IEnumerator LaunchLaser()
    {
        yield return new WaitForSeconds(_startWaitTime);

        if (_startOnAwake == false)
        {
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

    void IRestart.Restart()
    {
        if (_infiniteWorking == false)
        {
            StopAllCoroutines();
            _laserSwitcher.Restart(_startOnAwake);
            StartCoroutine(LaunchLaser());
        }
    }
}