using DG.Tweening;using UnityEngine;

public abstract class LoadingScreen : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    protected float Duration => _duration;
    
    public abstract Tween Appear();
    public abstract Tween Disappear();
}