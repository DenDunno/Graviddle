using UnityEngine;

public class FinishPortal : MonoBehaviour
{
    [SerializeField] private Transform _pullingPoint;

    public Transform PullingPoint => _pullingPoint;
}