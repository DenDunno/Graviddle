using System;
using UnityEngine;


[Serializable]
public class SwipeHandlerSwitcher : CharacterFallingEventsHandler
{
    [SerializeField] private SwipeHandler _swipeHandler;


    public override void OnCharacterStartFalling()
    {
        _swipeHandler.enabled = false;
    }


    public override void OnCharacterEndFalling()
    {
        _swipeHandler.enabled = true;
    }
}