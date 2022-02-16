using UnityEngine;


public class FinishPortal : MonoBehaviour, IGravityRotation
{
    [SerializeField] private PortalDisappearance _portalDisappearance;
    [SerializeField] private CharacterToPortalPulling _pullingAnimation;
    [SerializeField] private PortalView _portalView;
    private WinState _characterWinState;


    public void Init(WinState winState)
    {
        _characterWinState = winState;
        _portalView.Init();
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