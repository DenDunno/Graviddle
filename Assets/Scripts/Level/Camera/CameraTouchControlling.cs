using UnityEngine;


public class CameraTouchControlling : MonoBehaviour
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
            Vector3 newCameraPosition = -Input.GetTouch(0).deltaPosition;
            newCameraPosition *= _movingSpeed * Time.deltaTime;
            newCameraPosition = transform.rotation * newCameraPosition;
            newCameraPosition = transform.position + newCameraPosition;

            _cameraBorders.ClampCamera(ref newCameraPosition);
            transform.position = newCameraPosition;
        }
    }
}