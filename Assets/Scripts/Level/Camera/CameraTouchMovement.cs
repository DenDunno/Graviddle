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
            Vector3 cameraPosition = Input.GetTouch(0).deltaPosition;
            cameraPosition *= -_movingSpeed * Time.deltaTime;
            cameraPosition = transform.rotation * cameraPosition;
            cameraPosition = transform.position + cameraPosition;

            _cameraBorders.ClampCamera(ref cameraPosition);

            transform.position = cameraPosition;
        }
    }
}