using UnityEngine;


public class CameraTouchMovement : MonoBehaviour
{    
    private readonly float _movingSpeed = 1f;
    private CameraBorders _cameraBorders;


    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
    }


    private void LateUpdate()
    {         
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 newcameraPosition = -Input.GetTouch(0).deltaPosition;
            newcameraPosition *= _movingSpeed * Time.deltaTime;
            newcameraPosition = transform.rotation * newcameraPosition;
            newcameraPosition = transform.position + newcameraPosition;

            _cameraBorders.ClampCamera(ref newcameraPosition);
            transform.position = newcameraPosition;
        }
    }
}