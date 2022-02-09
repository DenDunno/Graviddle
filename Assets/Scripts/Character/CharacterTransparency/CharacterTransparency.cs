using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class CharacterTransparency : IRestart, IAfterRestart
{
    private const float _timeBeforeDisappearance = 1f;
    private readonly SpriteTransparency _spriteTransparency;


    public CharacterTransparency(SpriteRenderer spriteRenderer)
    {
        _spriteTransparency = new SpriteTransparency(spriteRenderer);
        _spriteTransparency.BecomeTransparentNow();
        _spriteTransparency.BecomeOpaque();
    }


    public async void BecomeTransparentWithDelay()
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