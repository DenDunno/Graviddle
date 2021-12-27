using DG.Tweening;
using UnityEngine;
using Zenject;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private PortalDisappearance _portalDisappearance;


    private void Start()
    {
        _portalDisappearance = new PortalDisappearance(5f, this);
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
        const float characterPullDuration = 2f;
        const float yOffset = 0.6f;

        Vector2 targetPosition = transform.position - transform.up * yOffset;

        _character.transform.DOMove(targetPosition, characterPullDuration);

        _portalDisappearance.Disappear();
    }
}