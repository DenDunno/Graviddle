using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;


public class SwipeHandlerSwitcher : MonoBehaviour , IDragHandler
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [Inject] private readonly CharacterStates _characterStates = null;


    private void OnEnable()
    {
        _characterStates.FallState.CharacterGroundedChanged += OnCharacterGroundedChanged;
    }


    private void OnDisable()
    {
        _characterStates.FallState.CharacterGroundedChanged -= OnCharacterGroundedChanged;
    }
    

    private void OnCharacterGroundedChanged(bool isGrounded)
    {
        _swipeHandler.enabled = isGrounded;
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}