using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserDistance = 5;
    private LineRenderer _laser;

    [SerializeField]
    private ParticleSystemRenderer[] _sourceEnergyParticles = null;

    [SerializeField]
    private ParticleSystem[] _launchParticles = null;

    [SerializeField]
    private float speedOfDistortion = 0.01f;
    private string _noiseAmountName = "Vector1_98180462";
    private string _noisePowerName  = "Vector1_CEBC9821";

    private Action <Material , float> _setDistortion;
    private bool glassy = false;


    private void Start()
    {
        Vector3 targetPosition = transform.position - transform.up / 2 - transform.right * 0.04f;

        _laser = GetComponentInChildren<LineRenderer>();
        _laser.SetPosition(0, targetPosition);
        _laser.SetPosition(1, targetPosition + transform.up * _laserDistance);


        _setDistortion = Disappear;
    }


    private void SetForceVector(Vector3 vector , ParticleSystem particleSystem)
    {
        var targetVector = particleSystem.transform.parent.position;
        targetVector.x = particleSystem.forceOverLifetime.xMultiplier;
    }


    public void StartCor()
    {
        StartCoroutine(SwichOff());
    }


    private void Disappear(Material material , float noiseDistortion)
    {
        material.SetFloat(_noiseAmountName, noiseDistortion);
        material.SetFloat(_noisePowerName, 6 * noiseDistortion - 0.5f);
    }


    private IEnumerator SwichOff()
    {
        StartCoroutine(MakeDistortion(glassy, (result) => { _setDistortion(_sourceEnergyParticles[0].material, result); }));
        StartCoroutine(MakeDistortion(glassy, (result) => { _setDistortion(_sourceEnergyParticles[1].material, result); }));

        yield return StartCoroutine(MakeDistortion(glassy, (result) => { _setDistortion(_laser.material, result); }));

        glassy = !glassy;
    }


    private IEnumerator MakeDistortion(bool glassy, Action<float> callback)
    {
        float noiseDistortion = glassy ? 1 : 0.25f;

        while (glassy ? noiseDistortion > 0.25 : noiseDistortion < 1 )
        {
            noiseDistortion += glassy ? -speedOfDistortion : speedOfDistortion;
            callback(noiseDistortion);
            yield return new WaitForFixedUpdate();
        }
    }
}
