using UnityEngine;


public class CameraTouchControlling : MonoBehaviour
{
    [SerializeField] private CameraBorders _cameraBorders = null;
    private readonly float _movingSpeed = 1f;


    private void LateUpdate()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Vector3 newCameraPosition = new Vector2(Input.GetAxis("Mouse X") , Input.GetAxis("Mouse Y")) * -100;
            MoveCamera(ref newCameraPosition);
        }

        #else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 newCameraPosition = -Input.GetTouch(0).deltaPosition;
            MoveCamera(ref newCameraPosition);
        }
        #endif  
    }


    private void MoveCamera(ref Vector3 newCameraPosition)
    {
        newCameraPosition *= _movingSpeed * Time.deltaTime;
        newCameraPosition = transform.rotation * newCameraPosition;
        newCameraPosition = transform.position + newCameraPosition;
        newCameraPosition.z = transform.position.z;

        _cameraBorders.ClampCamera(ref newCameraPosition);
        transform.position = newCameraPosition;
    }
}