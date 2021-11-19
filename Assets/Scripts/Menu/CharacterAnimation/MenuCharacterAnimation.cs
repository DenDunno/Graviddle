using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class MenuCharacterAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _canvas = null;
    private readonly float _animationDuration = 2.625f;
    private readonly float _intervalBetweenAnimations = 0.7f;
    private RectTransform _transform;
    private List<AnimationPath> _animationsPoints;
    

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        _animationsPoints = MenuCharacterAnimationPoints.GetAnimationPoints(_canvas , 9);
        _transform = GetComponent<RectTransform>();

        _transform.anchoredPosition = _animationsPoints[0].StartPosition;

        const int numOfBorders = 4;

        for (int currentAnimation = 0; currentAnimation < numOfBorders; ++currentAnimation)
        {
            int nextAnimation = (currentAnimation == numOfBorders - 1) ? 0 : currentAnimation + 1;

            Vector2 targetPosition = _animationsPoints[currentAnimation].EndPosition;
            Vector2 resetPosition = _animationsPoints[nextAnimation].StartPosition;

            sequence.Append(AnimateCharacter(targetPosition, resetPosition));
            sequence.AppendInterval(_intervalBetweenAnimations);
        }

        sequence.SetLoops(-1);
    }


    private Tween AnimateCharacter(Vector2 endPosition , Vector2 nextStartPosition)
    {
        Tween characterAnimation = _transform.DOAnchorPos(endPosition, _animationDuration).SetEase(Ease.InCubic);

        characterAnimation.onComplete += () =>
        {
            _transform.anchoredPosition = nextStartPosition;
            transform.rotation *= Quaternion.Euler(0 , 0 , -90);
        };

        return characterAnimation;
    }
}
