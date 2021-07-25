using System.Collections;
using UnityEngine;


public class FinishPortalCapture : MonoBehaviour
{
    [SerializeField] private FinishPortal _finishPortal = null;
    [SerializeField] private GameObject _touchPanel = null;
    [SerializeField] private CharacterCapture _characterCapture;

    private readonly float _epsilon = 0.4f;
    private readonly float _waitTime = 1f;
    private readonly float _captureSpeed = 2f;


    private void LateUpdate()
    {
        Vector2 newCameraPosition = Vector2.Lerp(transform.position, _finishPortal.transform.position, _captureSpeed * Time.deltaTime);
        transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, transform.position.z);

        if (Vector2.Distance(transform.position, _finishPortal.transform.position) <= _epsilon)
        {
            enabled = false;
            StartCoroutine(WaitToSeePortal());
        }
    }


    public void ToggleFinishPortalCapture(bool finishCaptureEnabled) // called by finish button
    {
        enabled = finishCaptureEnabled;
        _characterCapture.enabled = !finishCaptureEnabled;
        _touchPanel.SetActive(!finishCaptureEnabled);
    }


    private IEnumerator WaitToSeePortal()
    {
        yield return new WaitForSeconds(_waitTime);

        ToggleFinishPortalCapture(false);
    }
}
