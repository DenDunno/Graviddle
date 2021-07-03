using UnityEngine;


[RequireComponent(typeof(CameraBorders))]
public class CameraCapture : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [SerializeField] private FinishPortal _finishPortal = null;
    private Transform _target;

    private readonly float _captureSpeed = 2f;
    private CameraBorders _cameraBorders;


    private void Start()
    {
        _target = _character.transform;
        _cameraBorders = GetComponent<CameraBorders>();
    }


    private void LateUpdate()
    {
        Vector3 cameraPosition = _target.position;
        cameraPosition.z = transform.position.z;

        _cameraBorders.ClampCamera(ref cameraPosition);

        transform.position = Vector3.Lerp(transform.position, cameraPosition, _captureSpeed * Time.deltaTime);
    }


    public void CaptureFinishPortal() // called by button
    {
        _target = _finishPortal.transform;
    }


    public void CaptureCharacter()
    {
        _target = _character.transform;
    }
}