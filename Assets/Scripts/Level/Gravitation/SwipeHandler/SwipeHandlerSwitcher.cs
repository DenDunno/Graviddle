using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


[RequireComponent(typeof(SwipeHandler))]
public class SwipeHandlerSwitcher : MonoBehaviour , IDragHandler
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private SwipeHandler _swipeHandler;


    private void Start()
    {
        _swipeHandler = GetComponent<SwipeHandler>();
    }


    private void OnEnable()
    {
        _characterStatesPresenter.FallState.CharacterFalling += OnCharacterFalling;
        _characterStatesPresenter.IdleState.CharacterGrounded += OnCharacterGrounded;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.FallState.CharacterFalling -= OnCharacterFalling;
        _characterStatesPresenter.IdleState.CharacterGrounded -= OnCharacterGrounded;
    }


    private void OnCharacterFalling()
    {
        _swipeHandler.enabled = false;
    }


    private void OnCharacterGrounded()
    {
        _swipeHandler.enabled = true;
    }
    

    public void OnDrag(PointerEventData eventData)
    {
    }
}