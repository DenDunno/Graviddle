using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CameraCapture))]
public class FinishPortalCapture : MonoBehaviour
{
    [SerializeField] private FinishPortal _finishPortal = null;
    [SerializeField] private GameObject _touchPanel = null;
    private CameraCapture _cameraCapture;

    private readonly float _waitTime = 1f;


    private void Start()
    {
        _cameraCapture = GetComponent<CameraCapture>();
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, _finishPortal.transform.position) <= 1)
        {
            enabled = false;
            StartCoroutine(WaitToSeePortal());
        }
    }


    private IEnumerator WaitToSeePortal()
    {
        yield return new WaitForSeconds(_waitTime);

        _cameraCapture.CaptureCharacter();
        _touchPanel.SetActive(true);
    }
}
