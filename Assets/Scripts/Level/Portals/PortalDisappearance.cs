using System.Collections;
using UnityEngine;


public class PortalDisappearance 
{
    private float _speedOfDisappearing = 1f;
    private float _timeBeforeDisappearance = 1.3f;


    public IEnumerator Disappear(Transform transform)
    {
        yield return new WaitForSeconds(_timeBeforeDisappearance);

        while (transform.localScale.x >= 0)
        {
            float temp = _speedOfDisappearing * Time.deltaTime;
            Vector3 disappearVector = new Vector2(temp, temp);

            transform.localScale -= disappearVector;
            yield return new WaitForFixedUpdate();
        }        
    }
}