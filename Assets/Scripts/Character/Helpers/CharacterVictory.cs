using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class CharacterVictory
{
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);

    [SerializeField] private GameObject _winCanvas = null;
    [SerializeField] private GameObject _touchCanvas = null;
    [SerializeField] private GameObject _gameplayCanvas = null;


    public void FinishLevel(Character character , FinishPortal finishPortal)
    {
        ToggleWinUI();
        TurnOffCharacterLogic(character);
        character.StartCoroutine(PullCharacterToThePortal(character.transform, finishPortal.transform));
    }


    private void ToggleWinUI()
    {
        _touchCanvas.SetActive(false);
        _gameplayCanvas.SetActive(false);
        _winCanvas.SetActive(true);
    }


    private void TurnOffCharacterLogic(Character character)
    {
        CharacterStateMachine stateMachine = character.GetComponent<CharacterStateMachine>();
        Animator animator = character.GetComponent<Animator>();
        Rigidbody2D rigidbody = character.GetComponent<Rigidbody2D>();

        stateMachine.enabled = false;
        animator.Play(CharacterAnimations.Fall);

        rigidbody.isKinematic = true;
        rigidbody.velocity = new Vector2(0, 0);
    }


    private IEnumerator PullCharacterToThePortal(Transform character , Transform finishPortal)
    {
        float characterPullDuration = 2f;
        Vector2 targetPosition = finishPortal.transform.position - finishPortal.transform.up * 0.6f;

        character.DOMove(targetPosition, characterPullDuration);

        yield return _portalDisappearance.Disappear(finishPortal);
    }   
}