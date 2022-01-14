using DG.Tweening;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class MenuCharacterAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas;
    private RectTransform _transform;
    private readonly float _animationDuration = 2.625f;
    private readonly float _intervalBetweenAnimations = 0.7f;


    private void Start()
    {
        _transform = GetComponent<RectTransform>();
        Sequence sequence = DOTween.Sequence();

        foreach (AnimationPath animationPath in MenuCharacterAnimationPoints.GetAnimationPoints(_canvas))
        {
            sequence.Append(AnimateCharacter(animationPath.StartPosition, animationPath.EndPosition));
            sequence.AppendInterval(_intervalBetweenAnimations);
        }

        sequence.SetLoops(-1);
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
}
