using UnityEngine;


public class StartPortal : MonoBehaviour, IRestartableComponent, IAfterRestartComponent
{
    private PortalDisappearance _portalDisappearance;


    private void Start()
    {
        _portalDisappearance = new PortalDisappearance(2.5f, this);
        _portalDisappearance.Disappear();
    }


    void IRestartableComponent.Restart()
    {
        _portalDisappearance.StopAndResetAnimation();
    }


    void IAfterRestartComponent.Restart()
    {
        _portalDisappearance.Disappear();
    }
}