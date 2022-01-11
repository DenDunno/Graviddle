using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CameraClamping))]
public class CameraIconSwitcher : MonoBehaviour
{
    [SerializeField] private Button _cameraIcon;
    private CameraClamping _cameraClamping;
    private readonly float _epsilon = 0.3f;


    private void Start()
    {
        _cameraClamping = GetComponent<CameraClamping>();
    }


    private void FixedUpdate()
    {
        Vector3 clampedPosition = _cameraClamping.Clamp(transform.position);
        _cameraIcon.interactable = (clampedPosition - transform.position).magnitude <= _epsilon;
    }
}
