using DG.Tweening;
using System.Collections;
using UnityEngine;


[System.Serializable]
public class CharacterVictory
{
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);

    [SerializeField] private Canvas _winCanvas = null;
    [SerializeField] private Canvas _touchCanvas = null;
    [SerializeField] private Canvas _gameplayCanvas = null;


    public void FinishLevel(Character character , FinishPortal finishPortal)
    {
        ShowWinUI();
        TurnOffCharacterLogic(character);
        character.StartCoroutine(PullCharacterToThePortal(character.transform, finishPortal.transform));
    }


    private void ShowWinUI()
    {
        _touchCanvas.gameObject.SetActive(false);
        _gameplayCanvas.gameObject.SetActive(false);
        _winCanvas.gameObject.SetActive(true);
    }


    private void TurnOffCharacterLogic(Character character)
    {
        var stateMachine = character.GetComponent<CharacterStateMachine>();
        var animator = character.GetComponent<Animator>();
        var rigidbody = character.GetComponent<Rigidbody2D>();

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