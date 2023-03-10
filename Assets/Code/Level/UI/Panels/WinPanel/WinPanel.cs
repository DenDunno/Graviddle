using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField] private WinAnimation _winAnimation;
    private readonly float _characterAnimationDuration = 2f;
    
    protected override async UniTask OnShow()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_characterAnimationDuration)); 
        
        _winAnimation.Play();
    }
}