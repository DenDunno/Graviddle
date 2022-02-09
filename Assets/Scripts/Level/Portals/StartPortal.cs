using UnityEngine;


public class StartPortal : MonoBehaviour, IRestart, IAfterRestart
{
    [SerializeField] private PortalDisappearance _portalDisappearance;


    private void Start()
    {
        _portalDisappearance.Disappear();
    }


    void IRestart.Restart()
    {
        _portalDisappearance.ResetAnimation();
    }


    void IAfterRestart.Restart()
    {
        _portalDisappearance.Disappear();
    }
}