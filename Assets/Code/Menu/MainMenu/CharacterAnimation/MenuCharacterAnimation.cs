using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MenuCharacterAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas;
    private RectTransform _transform;
    private const float _animationDuration = 2.625f;
    private const float _intervalBetweenAnimations = 0.7f;
    private Sequence _animation;
    
    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        _animation = DOTween.Sequence();

        foreach (AnimationPath animationPath in MenuCharacterAnimationPoints.GetAnimationPoints(_canvas))
        {
            _animation.Append(AnimateCharacter(animationPath.StartPosition, animationPath.EndPosition));
            _animation.AppendInterval(_intervalBetweenAnimations);
        }

        _animation.SetLoops(-1);
    }

    private Tween AnimateCharacter(Vector2 startPosition , Vector2 endPosition)
    {
        Tween characterAnimation = _transform.DOAnchorPos(endPosition, _animationDuration)
                                             .From(startPosition)
                                             .SetEase(Ease.InCubic);

        characterAnimation.onComplete += () =>
        {
            transform.rotation *= Quaternion.Euler(0 , 0 , -90);
        };

        return characterAnimation;
    }

    private void OnDestroy()
    {
        _animation.Kill();
    }
}
