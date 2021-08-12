using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class ImageFading 
{
    [SerializeField] private float _fadingSpeed = 0;
    [SerializeField] private float _brightenSpeed = 0;


    public IEnumerator ChangeAlphaChannel(bool becomeOpaque , Action<float> setFunction)
    {
        float alphaChannel = becomeOpaque ? 0 : 1;
        float fadingSpeed = becomeOpaque ? _fadingSpeed : -_brightenSpeed;

        while (becomeOpaque ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            setFunction(alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}