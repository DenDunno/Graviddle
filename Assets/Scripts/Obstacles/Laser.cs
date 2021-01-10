using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Obstacle
{
    [SerializeField]
    private bool _awake = true;

    [SerializeField]
    private float _laserDistance = 5;

    [SerializeField]
    private bool _constDistortionSpeed = false;

    [SerializeField]
    private float _distortionSpeed = 0.3f;

    [SerializeField]
    private float _startWaitTime = 2f;

    [SerializeField]
    private float _workTime = 3f;

    [SerializeField]
    private float _coolDownTime = 2f;

    [SerializeField]
    private ParticleSystemRenderer[] _sourceEnergyParticles = null;

    private LineRenderer _laser;
    private BoxCollider2D _collider;
    
    private string _noiseAmountName = "Vector1_98180462";
    private string _noisePowerName  = "Vector1_CEBC9821";
    private string _noiseDirectionName = "Vector2_A7335824";

    private Action <Material , float> _setDistortion;
    private bool _enabled = true;
    private bool _restart = false;

    private Coroutine _launchLaser;


    private void Start()
    {
        _enabled = _awake;

        // просто подобрал значения
        Vector3 targetPosition = transform.position - transform.up / 2 - transform.right * 0.04f;

        _laser = GetComponentInChildren<LineRenderer>();
        _laser.SetPosition(0, targetPosition);
        _laser.SetPosition(1, targetPosition + transform.up * _laserDistance);

        _sourceEnergyParticles[0].material.SetVector(_noiseDirectionName, transform.up * 1.5f);
        _sourceEnergyParticles[1].material.SetVector(_noiseDirectionName, transform.up * -1.5f);

        _collider = GetComponent<BoxCollider2D>();
        _collider.size = new Vector2(_collider.size.x, _laserDistance);
        _collider.offset = new Vector2(_collider.offset.x, 0.5f * _laserDistance - 0.5f); 
        // Offset.y(size.y) = 0.5 * size.y - 0.5 функция зависимости смещение от размера

        if (!_awake) // если лазер выключен, делаем прозрачным
        {
            SetDistortion(_sourceEnergyParticles[0].material, 1);
            SetDistortion(_sourceEnergyParticles[1].material, 1);
            SetDistortion(_laser.material, 1);
        }

        _setDistortion = SetDistortion;

        _launchLaser = StartCoroutine(LaunchLaser());
    }


    private IEnumerator LaunchLaser()
    {
        yield return new WaitForSeconds(0.1f);
        
        _restart = false;
        _collider.enabled = _awake;
        _enabled = _awake;

        if (_enabled == false)
        {
            yield return new WaitForSeconds(_startWaitTime);
            yield return StartCoroutine(ToggleLaser());
        }

        while (_restart == false)
        {
            yield return new WaitForSeconds(_workTime);
            yield return StartCoroutine(ToggleLaser());

            yield return new WaitForSeconds(_coolDownTime);
            yield return StartCoroutine(ToggleLaser());
        }
    }


    private void SetDistortion(Material material , float noiseDistortion)
    {
        material.SetFloat(_noiseAmountName, noiseDistortion);
        material.SetFloat(_noisePowerName, 4.4f * noiseDistortion + 0.9f);
        // F(x) = 4.4x + 0.9
        // область значения F([0.25 , 1]) = [2 , 5.3]
        // при noiseAmount = 1 и noisePower = 5.3 лазер прозрачен
    }


    private IEnumerator ToggleLaser()
    {
        if (_enabled == false)
        _collider.enabled = true;

        StartCoroutine(MakeDistortion((result) => { _setDistortion(_sourceEnergyParticles[0].material, result); }));
        StartCoroutine(MakeDistortion((result) => { _setDistortion(_sourceEnergyParticles[1].material, result); }));
        yield return StartCoroutine(MakeDistortion((result) => { _setDistortion(_laser.material, result); }));

        _enabled = !_enabled;
    }


    private IEnumerator MakeDistortion(Action<float> callback)
    {
        float minNoiseDistortion = 0.25f;
        float maxNoiseDistortion = 1f;

        float currentDistortion = _enabled ? minNoiseDistortion : maxNoiseDistortion;
        float distortionSpeed = _distortionSpeed;

        if (_enabled == false && _constDistortionSpeed == false)
            distortionSpeed = 3 * distortionSpeed;

        while ((_enabled ? currentDistortion < maxNoiseDistortion : currentDistortion > minNoiseDistortion) && !_restart)
        {
            currentDistortion += distortionSpeed * Time.deltaTime * (_enabled ? 1 : -1);
            
            if (currentDistortion > 0.75f && _enabled) // когда лазер почти потух
                _collider.enabled = false;

            callback(currentDistortion);
            yield return new WaitForEndOfFrame();
        }
    }


    public override void Restart()
    {
        StopCoroutine(_launchLaser);
        StopCoroutine(ToggleLaser());
        _restart = true;

        SetDistortion(_sourceEnergyParticles[0].material, _awake ? 0.25f : 1);
        SetDistortion(_sourceEnergyParticles[1].material, _awake ? 0.25f : 1);
        SetDistortion(_laser.material, _awake ? 0.25f : 1);        

        _launchLaser = StartCoroutine(LaunchLaser());
    }
}
