using UnityEngine;
using UnityEngine.UI;


public class CameraIconSwitcher : MonoBehaviour
{
    [SerializeField] private Button _cameraIcon = null;
    [SerializeField] private CameraBorders _cameraBorders = null;
    private readonly float _epsilon = 0.3f;
    

    private void FixedUpdate()
    {
        Vector3 newCameraPosition = transform.position;

        _cameraBorders.ClampCamera(ref newCameraPosition);
        _cameraIcon.interactable = (newCameraPosition - transform.position).magnitude <= _epsilon;
    }
}
