using UnityEngine;


public class ClosedPathMotion : MonoBehaviour
{
    [SerializeField] private ClosedPathMotionCalculator _motionCalculator = null;

    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    [SerializeField] private Vector3 _targetPosition = Vector3.zero;


    private void Start()
    {
        _motionCalculator.Init();
    }


    private void Update()
    {
        float lerp = _motionCalculator.EvaluateLerpPosition();
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, lerp);
    }
}