using System.Collections;
using DG.Tweening;
using UnityEngine;
using Zenject;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private Character _character = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);


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
        StartCoroutine(PullCharacterToThePortal());
    }


    private IEnumerator PullCharacterToThePortal()
    {
        const float characterPullDuration = 2f;
        const float yOffset = 0.6f;

        Vector2 targetPosition = transform.position - transform.up * yOffset;

        _character.transform.DOMove(targetPosition, characterPullDuration);

        yield return _portalDisappearance.Disappear(transform);
    }
}