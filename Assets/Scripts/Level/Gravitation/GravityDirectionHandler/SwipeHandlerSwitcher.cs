using UnityEngine;


public class SwipeHandlerSwitcher : CharacterFallingEventsHandler, IRestartableComponent
{
    [SerializeField] private GravityDirectionHandler _gravityDirectionHandler;


    protected override void OnCharacterStartFalling()
    {
        _gravityDirectionHandler.enabled = false;
    }


    protected override void OnCharacterEndFalling()
    {
        _gravityDirectionHandler.enabled = true;
    }

    
    void IRestartableComponent.Restart()
    {
        OnCharacterEndFalling();
    }
}