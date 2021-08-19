using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;


public class RewardListUI : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement = null;
    [SerializeField] private RewardListSwitcher _rewardListSwitcher = null;
    [SerializeField] private Transform _rewardListTransform = null;

    [SerializeField] private TMP_Text _goldUI = null;
    [SerializeField] private TMP_Text _silverUI = null;


    public void SetRewardListUI(int gold , int silver)
    {
        _goldUI.text = gold.ToString();
        _silverUI.text = silver.ToString();
    }


    private void Update()
    {
        bool isTweening = DOTween.IsTweening(_rewardListTransform);
        bool isActive = _rewardListTransform.gameObject.activeInHierarchy;
        bool canBeHidden = !isTweening && isActive;

        if (_characterMovement.MoveDirection != Vector2.zero && canBeHidden)
        {
            StartCoroutine(HideRewardList());
        }
    }


    private IEnumerator HideRewardList()
    {
        const float animationDuration = 1.5f;

        enabled = false;

        _rewardListSwitcher.ToggleRewardListUI();
        yield return new WaitForSeconds(animationDuration);

        enabled = true;
    }
}
