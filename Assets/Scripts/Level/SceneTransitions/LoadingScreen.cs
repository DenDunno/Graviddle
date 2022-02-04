using DG.Tweening;using UnityEngine;


public abstract class LoadingScreen : MonoBehaviour
{
    [SerializeField] private float _inspectorDuration = 1f;
    protected float Duration => _inspectorDuration;
    
    public abstract Tween Appear();
    public abstract Tween Disappear();
}