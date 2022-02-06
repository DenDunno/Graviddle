using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class CharacterVFX : CharacterFallingEventsHandler, IRestartableComponent
{
    [SerializeField] private AssetReference _fallingDustReference;
    [SerializeField] private TrailRenderer _trailRenderer;


    protected override void OnCharacterStartFalling()
    {
        _trailRenderer.emitting = true;
    }


    protected override void OnCharacterEndFalling()
    {
        ParticlesHelper.PlayAndDestroy(_fallingDustReference, transform);
        _trailRenderer.emitting = false;
    }


    void IRestartableComponent.Restart()
    {
        OnCharacterEndFalling();
    }
}