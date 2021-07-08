using System;
using System.Collections;
using UnityEngine;


public class ScreenFading 
{
    public IEnumerator ChangeAlphaChannel(float fadingSpeed, bool becomeOpaque , Action<float> callBack)
    {
        float alphaChannel = becomeOpaque ? 0 : 1;
        fadingSpeed *= becomeOpaque ? 1 : -1;

        while (becomeOpaque ? alphaChannel <= 1 : alphaChannel >= 0)
        {
            alphaChannel += fadingSpeed * Time.deltaTime;
            callBack(alphaChannel);
            yield return new WaitForFixedUpdate();
        }
    }
}