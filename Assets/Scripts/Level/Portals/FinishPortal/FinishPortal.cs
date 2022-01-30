using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private PortalDisappearance _portalDisappearance;
    [SerializeField] private CharacterToPortalPulling _pullingAnimation;
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;


    private void OnEnable()
    {
        _characterStatesPresenter.WinState.CharacterWon += OnCharacterWon;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.WinState.CharacterWon -= OnCharacterWon;
    }
    

    private void OnCharacterWon()
    {
        StartCoroutine(_pullingAnimation.PullCharacterToPortal());
        _portalDisappearance.Disappear();
    }
}