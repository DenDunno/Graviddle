using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class CharacterTransparency : IRestart, IAfterRestart, ISubscriber, IInitializable
{
    private const float _timeBeforeDisappearance = 1f;
    private readonly SpriteTransparency _spriteTransparency;
    private readonly WinState _winState;

    public CharacterTransparency(SpriteRenderer spriteRenderer, WinState winState)
    {
        _spriteTransparency = new SpriteTransparency(spriteRenderer);
        _winState = winState;
    }

    void IInitializable.Init()
    {
        _spriteTransparency.BecomeTransparentNow();
        _spriteTransparency.BecomeOpaque();
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += BecomeTransparentWithDelay;
    }
    
    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= BecomeTransparentWithDelay;
    }

    private async void BecomeTransparentWithDelay()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_timeBeforeDisappearance));

        _spriteTransparency.BecomeTransparent();
    }

    void IRestart.Restart()
    {
        _spriteTransparency.StopAnimation();
        _spriteTransparency.BecomeTransparentNow();
    }

    void IAfterRestart.Restart()
    {
        _spriteTransparency.BecomeOpaque();
    }
}