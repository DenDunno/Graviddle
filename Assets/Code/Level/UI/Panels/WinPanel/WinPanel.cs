using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField] private WinAnimation _winAnimation;

    protected override async UniTask OnShow()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2f)); // character animation
        
        _winAnimation.Play();
    }
}