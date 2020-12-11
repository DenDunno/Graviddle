using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserDistance = 5;

    [SerializeField]
    private ParticleSystemRenderer[] _sourceEnergyParticles = null;

    [SerializeField]
    private float _workTime = 3f;

    [SerializeField]
    private float _coolDownTime = 2f;

    //[SerializeField]
    //private ParticleSystem[] _launchParticles = null;

    private LineRenderer _laser;

    private float _speedOfDistortion = 0.01f;
    private string _noiseAmountName = "Vector1_98180462";
    private string _noisePowerName  = "Vector1_CEBC9821";

    private Action <Material , float> _setDistortion;
    private bool _enabled = true;

    private BoxCollider2D _collider;


    private void Start()
    {
        // просто подобрал значения
        Vector3 targetPosition = transform.position - transform.up / 2 - transform.right * 0.04f;

        _laser = GetComponentInChildren<LineRenderer>();
        _laser.SetPosition(0, targetPosition);
        _laser.SetPosition(1, targetPosition + transform.up * _laserDistance);

        _collider = GetComponent<BoxCollider2D>();
        _collider.size = new Vector2(_collider.size.x, _laserDistance);
        _collider.offset = new Vector2(_collider.offset.x, 0.5f * _laserDistance - 0.5f); 
        // Offset.y(size.y) = 0.5 * size.y - 0.5 функция зависимости смещение от размера

        _setDistortion = Disappear;

        StartCoroutine(LaunchLaser());
    }


    //private void SetForceVector(Vector3 vector , ParticleSystem particleSystem)
    //{
    //    var targetVector = particleSystem.transform.parent.position;
    //    targetVector.x = particleSystem.forceOverLifetime.xMultiplier;
    //}


    private IEnumerator LaunchLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(_workTime);
            yield return StartCoroutine(ToggleLaser());

            yield return new WaitForSeconds(_coolDownTime);
            yield return StartCoroutine(ToggleLaser());
        }
    }


    private void Disappear(Material material , float noiseDistortion)
    {
        material.SetFloat(_noiseAmountName, noiseDistortion);
        material.SetFloat(_noisePowerName, 6 * noiseDistortion - 0.5f);
    }


    private IEnumerator ToggleLaser()
    {
        if (!_enabled)
        _collider.enabled = true;

        _speedOfDistortion = _enabled ? 0.005f : 0.015f;

        StartCoroutine(MakeDistortion((result) => { _setDistortion(_sourceEnergyParticles[0].material, result); }));
        StartCoroutine(MakeDistortion((result) => { _setDistortion(_sourceEnergyParticles[1].material, result); }));
        yield return StartCoroutine(MakeDistortion((result) => { _setDistortion(_laser.material, result); }));

        _enabled = !_enabled;
    }


    private IEnumerator MakeDistortion(Action<float> callback)
    {
        float noiseDistortion = _enabled ? 0.25f : 1;

        while (_enabled ? noiseDistortion < 1 : noiseDistortion > 0.25)
        {
            noiseDistortion += _enabled ? _speedOfDistortion : -_speedOfDistortion;

            if (noiseDistortion > 0.75f && _enabled) // когда лазер почти потух
                _collider.enabled = false;

            callback(noiseDistortion);
            yield return new WaitForFixedUpdate();
        }
    }
}
