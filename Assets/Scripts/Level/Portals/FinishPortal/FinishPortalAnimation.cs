using UnityEngine;


public class FinishPortalAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _motionCurve;
    private Vector3 _startPosition;


    private void Start()
    {
        _startPosition = transform.localPosition;

        _motionCurve.postWrapMode = WrapMode.Loop;
        _motionCurve.preWrapMode = WrapMode.Loop;
    }


    private void Update()
    {
        Vector3 offset = transform.up * _motionCurve.Evaluate(Time.time);

        if (transform != transform.root)
        {
            offset = transform.root.rotation * offset;
        }

        transform.localPosition = _startPosition + offset;
    }
}