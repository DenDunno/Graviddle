using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CameraBorders))]
public class CameraIconSwitcher : MonoBehaviour
{
    [SerializeField] private Button _cameraIcon = null;
    private CameraBorders _cameraBorders = null;
    private readonly float _epsilon = 0.3f;


    private void Start()
    {
        _cameraBorders = GetComponent<CameraBorders>();
    }


    private void FixedUpdate()
    {
        Vector3 targetCameraPosition = transform.position;

        _cameraBorders.ClampCamera(ref targetCameraPosition);
        _cameraIcon.interactable = (targetCameraPosition - transform.position).magnitude <= _epsilon;
    }
}
