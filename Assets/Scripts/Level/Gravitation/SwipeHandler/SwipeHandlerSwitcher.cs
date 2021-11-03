using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


public class SwipeHandlerSwitcher : MonoBehaviour , IDragHandler
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;


    private void OnEnable()
    {
        _characterStatesPresenter.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
    }
    

    private void OnCharacterGroundedChanged(bool isGrounded)
    {
        _swipeHandler.enabled = isGrounded;
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}