using System.Collections;
using UnityEngine;


public class PortalDisappearance 
{
    private readonly float _timeBeforeDisappearance = 1.3f;
    private readonly float _disappearingSpeed;


    public PortalDisappearance(float disappearingSpeed)
    {
        _disappearingSpeed = disappearingSpeed;
    }


    public IEnumerator Disappear(Transform transform)
    {
        yield return new WaitForSeconds(_timeBeforeDisappearance);

        while (transform.localScale.x >= 0)
        {
            float temp = _disappearingSpeed * Time.deltaTime;
            Vector3 disappearVector = new Vector2(temp, temp);

            transform.localScale -= disappearVector;
            yield return new WaitForFixedUpdate();
        }        
    }
}