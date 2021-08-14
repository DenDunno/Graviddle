using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class RewardListSwitcher : MonoBehaviour , IRestartableComponent
{
    [SerializeField] private PopUpAnimation _rewardListPopUpAnimation = null;
    [SerializeField] private PopUpAnimation _characterRotationsPopUpAnimation = null;
    [SerializeField] private Button _switchButton = null;
    

    public void ToggleRewardListUI()
    {
        PopUpAnimation uiToBeActivated = _rewardListPopUpAnimation;
        PopUpAnimation uiToBeDeactivated = _characterRotationsPopUpAnimation;

        if (_rewardListPopUpAnimation.GameObj.activeInHierarchy)
        {
            Algorithms.Swap(ref uiToBeDeactivated, ref uiToBeActivated);
        }

        PlayAnimation(uiToBeActivated, uiToBeDeactivated);
    }


    private void PlayAnimation(PopUpAnimation uiToBeActivated, PopUpAnimation uiToBeDeactivated)
    {
        _switchButton.interactable = false;

        uiToBeDeactivated.HideUI().onComplete += () =>
        {
            uiToBeDeactivated.GameObj.SetActive(false);
            uiToBeActivated.GameObj.SetActive(true);

            uiToBeActivated.ShowUI().onComplete += () =>
            {
                _switchButton.interactable = true;
            };
        };
    }


    void IRestartableComponent.Restart()
    {
        ResetUI(_rewardListPopUpAnimation.GameObj, true);
        ResetUI(_characterRotationsPopUpAnimation.GameObj , false);
    }


    private void ResetUI(GameObject ui , bool becomeActive)
    {
        Vector3 scale = becomeActive ? new Vector3(1, 1, 1) : Vector3.zero;

        DOTween.Kill(ui);
        ui.SetActive(becomeActive);
        ui.transform.localScale = scale;
    }
}