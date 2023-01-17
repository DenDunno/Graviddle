using DG.Tweening;
using UnityEngine;

public class LevelStarsAnimation : MonoBehaviour
{
    [SerializeField] private Material _shinyMaterial;
    private const float _duration = 1.25f;
    private const float _coolDown = 0.8f;
    private int _shinyValueId;
    private Sequence _animation;
    
    private void Start()
    {
        _shinyValueId = Shader.PropertyToID("_Shiny");
        AnimateStars();
    }

    private void AnimateStars()
    {
        _animation = DOTween.Sequence();

        _animation.Append(TweenShinyValue(-1, 1));
        _animation.AppendInterval(_coolDown);

        _animation.SetLoops(-1);
    }

    private Tween TweenShinyValue(float startValue, float targetValue)
    {
        return DOTween.To(SetShinyValue, startValue, targetValue, _duration).SetEase(Ease.Linear);
    }

    private void SetShinyValue(float shinyValue)
    {
        _shinyMaterial.SetFloat(_shinyValueId, shinyValue);
    }

    private void OnDestroy()
    {
        _animation.Kill();
    }
}