using UnityEngine;


public class FinishPortal : MonoBehaviour
{    
    [SerializeField] private CharacterToPortalPulling _pullingAnimation;
    private WinState _characterWinState;


    public void Init(WinState winState)
    {
        _characterWinState = winState;
    }


    private void OnEnable()
    {
        _characterWinState.CharacterWon += _pullingAnimation.Execute;
    }


    private void OnDisable()
    {
        _characterWinState.CharacterWon -= _pullingAnimation.Execute;
    }
}