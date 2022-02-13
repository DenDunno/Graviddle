using UnityEngine;
using System;


[Serializable]
public class LaserDistortion
{
    [SerializeField] private LineRenderer _lineRenderer;
    private MaterialPropertyBlock _propertyBlock;
    private readonly string _noiseDistortionName = "_NoiseAmount";
    private readonly string _noisePowerName = "_NoisePower";


    public void Init()
    {
        _propertyBlock = new MaterialPropertyBlock();
    }


    public void SetDistortion(float distortion)
    {
        _propertyBlock.SetFloat(_noiseDistortionName, distortion);
        _propertyBlock.SetFloat(_noisePowerName, EvaluateNoisePower(distortion));
        _lineRenderer.SetPropertyBlock(_propertyBlock);
    }


    private float EvaluateNoisePower(float distortion)
    {
        return 4.4f * distortion + 0.9f;
    }
}