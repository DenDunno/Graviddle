using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField] private WinAnimation _winAnimation;

    protected override void OnShow()
    {
        _winAnimation.Play();
    }
}