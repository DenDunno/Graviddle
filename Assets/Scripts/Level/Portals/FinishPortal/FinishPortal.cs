using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private AnimationCurve _motionCurve = null;

    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.position;

        _motionCurve.postWrapMode = WrapMode.Loop;
        _motionCurve.preWrapMode = WrapMode.Loop;
    }


    private void Update()
    {
        transform.position = _startPosition + transform.up * _motionCurve.Evaluate(Time.time);
    }
}