using DG.Tweening;
using UnityEngine;


[System.Serializable]
public class PopUpAnimation
{
    public GameObject GameObj => _gameObject;

    [SerializeField] private GameObject _gameObject = null;
    private readonly float _animationDuration = 1f;
    private readonly Vector3 _startScale = new Vector3(1 , 1, 1);
    

    public Tween ShowUI()
    {
        return _gameObject.transform.DOScale(_startScale, _animationDuration).SetEase(Ease.OutBack);
    }


    public Tween HideUI()
    {
        return _gameObject.transform.DOScale(Vector3.zero, _animationDuration).SetEase(Ease.InBack);
    }
}
