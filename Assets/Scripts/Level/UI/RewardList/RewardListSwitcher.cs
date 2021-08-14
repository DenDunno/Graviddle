using UnityEngine;
using UnityEngine.UI;


public class RewardListSwitcher : MonoBehaviour
{
    [SerializeField] private PopUpAnimation _rewardListPopUpAnimation = null;
    [SerializeField] private PopUpAnimation _characterRotationsPopUpAnimation = null;
    [SerializeField] private Button _switchButton = null;


    private void OnEnable()
    {
        _switchButton.onClick.AddListener(OnSwitchButtonClicked);
    }


    private void OnDisable()
    {
        _switchButton.onClick.RemoveListener(OnSwitchButtonClicked);
    }


    public void OnSwitchButtonClicked()
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
}