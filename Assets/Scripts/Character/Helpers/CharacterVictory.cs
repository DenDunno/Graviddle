using DG.Tweening;
using System.Collections;
using UnityEngine;


[System.Serializable]
public class CharacterVictory
{
    [SerializeField] private UIState _victoryState = null;
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);


    public void FinishLevel(Character character , FinishPortal finishPortal)
    {
        _victoryState.ActivateState();
        TurnOffCharacterLogic(character);
        character.StartCoroutine(PullCharacterToThePortal(character.transform, finishPortal.transform));
    }


    private void TurnOffCharacterLogic(Character character)
    {
        var stateMachine = character.GetComponent<CharacterStateMachine>();
        var animator = character.GetComponent<Animator>();
        var rigidbody = character.GetComponent<Rigidbody2D>();

        stateMachine.enabled = false;
        animator.Play(AnimatorCharacterController.States.Fall);

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