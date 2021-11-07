using System.Collections;
using UnityEngine;


[RequireComponent(typeof(CameraCapture))]
[RequireComponent(typeof(SpriteRenderer))]
public class FinishPortalCapture : MonoBehaviour
{
    [SerializeField] private UIState _gameplayUI = null;
    private CameraCapturePresenter _capturePresenter = null;
    private SpriteRenderer _spriteRenderer;
    private CameraCapture _finishPortalCapture;


    private void Start()
    {
        _capturePresenter = Camera.main.GetComponent<CameraCapturePresenter>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _finishPortalCapture = GetComponent<CameraCapture>();
    }


    public void ActivatePortalCapture()
    {
        StartCoroutine(ActivateCapture());
    }


    private IEnumerator ActivateCapture()
    {
        CameraCapture _lastCapture = _capturePresenter.GetTarget();
        const float _timeToSeePortal = 3f;

        _capturePresenter.CaptureObject(_finishPortalCapture);

        yield return new WaitWhile(() => _spriteRenderer.isVisible == false);
        yield return new WaitForSeconds(_timeToSeePortal);

        _capturePresenter.CaptureObject(_lastCapture);
        _gameplayUI.ActivateState();
    }
}
