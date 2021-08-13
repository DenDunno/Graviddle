﻿using UnityEngine;
using UnityEngine.UI;


public class RewardListSwitcher : MonoBehaviour
{
    [SerializeField] private RewardListUI _rewardListUi = null;
    [SerializeField] private CharacterRotationsUI _characterRotationsUi = null;
    [SerializeField] private Button _switchButton = null;

    private PopUpAnimation _rewardListPopUpAnimation;
    private PopUpAnimation _characterRotationsPopUpAnimation;


    private void Start()
    {
        _rewardListPopUpAnimation = new PopUpAnimation(_rewardListUi.transform);
        _characterRotationsPopUpAnimation = new PopUpAnimation(_characterRotationsUi.transform);
    }


    private void OnEnable()
    {
        _switchButton.onClick.AddListener(OnSwitchButtonClicked);
    }


    private void OnDisable()
    {
        _switchButton.onClick.RemoveListener(OnSwitchButtonClicked);
    }


    private void OnSwitchButtonClicked()
    {
        PopUpAnimation uiToBeActivated = _rewardListPopUpAnimation;
        PopUpAnimation uiToBeDeactivated = _characterRotationsPopUpAnimation;

        if (_rewardListUi.gameObject.activeInHierarchy)
        {
            Algorithms.Swap(uiToBeDeactivated , uiToBeActivated);;
        }

        PlayAnimation(uiToBeActivated , uiToBeDeactivated);
    }


    private void PlayAnimation(PopUpAnimation uiToBeActivated, PopUpAnimation uiToBeDeactivated)
    {
        _switchButton.interactable = false;

        uiToBeDeactivated.HideUI().onComplete += () =>
        {
            uiToBeActivated.ShowUI().onComplete += () =>
            {
                _switchButton.interactable = true;
            };
        };
    }
}