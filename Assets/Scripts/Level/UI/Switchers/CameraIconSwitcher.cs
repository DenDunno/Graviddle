using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CameraClamping))]
public class CameraIconSwitcher : MonoBehaviour
{
    [SerializeField] private Button _cameraIcon = null;
    private CameraClamping _cameraClamping = null;
    private readonly float _epsilon = 0.3f;


    private void Start()
    {
        _cameraClamping = GetComponent<CameraClamping>();
    }


    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = transform.position;

        _cameraClamping.ClampCamera(ref targetCameraPosition);
        _cameraIcon.interactable = (targetCameraPosition - transform.position).magnitude <= _epsilon;
    }
}
