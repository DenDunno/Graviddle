using System.Collections;
using UnityEngine;

// портал должен двигаться вверх-вниз. Идентичный функционал есть в пилы с ускорением
// OnTriggerEnter2D переписаный, поэтому персонаж не умрет 
abstract public class TargetPortal : SawAcceleration
{
    private float _speedOfDisappearing = 1f;
    private Vector3 _disappearVector;
    private float _timeBeforeDisappearance = 1.3f;


    protected IEnumerator Disappear()
    {
        yield return new WaitForSeconds(_timeBeforeDisappearance);

        while (transform.localScale.x >= 0)
        {
            float temp = _speedOfDisappearing * Time.deltaTime;
            _disappearVector = new Vector2(temp, temp);

            transform.localScale -= _disappearVector;
            yield return new WaitForFixedUpdate();
        }
    }
}
