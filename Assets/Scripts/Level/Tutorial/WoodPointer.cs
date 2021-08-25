using System.Collections;
using Coffee.UIEffects;
using UnityEngine;

public class WoodPointer : MonoBehaviour
{
    private readonly float _dissolvingSpeed = 0.5f;
    [SerializeField] private UIDissolve _dissolveImage = null;
    

    public void ShowImage(int delayInMilliseconds)
    {
        StartCoroutine(ShowImageSmoothly(delayInMilliseconds));
    }


    private IEnumerator ShowImageSmoothly(int delayInMilliseconds)
    {
        yield return new WaitForSeconds(delayInMilliseconds / 1000f);

        while (_dissolveImage.effectFactor >= 0)
        {
            _dissolveImage.effectFactor -= _dissolvingSpeed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}