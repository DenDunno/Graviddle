using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private PortalDisappearance _portalDisappearance;
    [SerializeField] private CharacterToPortalPulling _pullingAnimation;
    private WinState _characterWinState;


    public void Init(WinState winState)
    {
        _characterWinState = winState;
    }


    private void OnEnable()
    {
        _characterWinState.CharacterWon += OnCharacterWon;
    }


    private void OnDisable()
    {
        _characterWinState.CharacterWon -= OnCharacterWon;
    }
    

    private void OnCharacterWon()
    {
        StartCoroutine(_pullingAnimation.PullCharacterToPortal());
        _portalDisappearance.Disappear();
    }
}