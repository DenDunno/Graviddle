using LeTai.Asset.TranslucentImage;
using UnityEngine;


public class BlurSwitcher : MonoBehaviour
{
    [SerializeField] private ScalableBlurConfig _blurConfig = null;
    private readonly float _targetBlur = 12f;


    private void Start()
    {
        DeactivateBlur();
    }


    public void ActivateBlur()
    {
        _blurConfig.Strength = _targetBlur;
    }


    public void DeactivateBlur()
    {
        _blurConfig.Strength = 0;
    }
}
