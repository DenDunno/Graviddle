using UnityEngine;
using Zenject;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private PortalDisappearance _portalDisappearance;
    private CharacterToPortalPulling _pullingAnimation;


    private void Start()
    {
        _portalDisappearance = new PortalDisappearance(5f, this);
        _pullingAnimation = new CharacterToPortalPulling(this, _character);
    }


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