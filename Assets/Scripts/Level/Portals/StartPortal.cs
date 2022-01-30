using UnityEngine;


public class StartPortal : MonoBehaviour, IRestartableComponent, IAfterRestartComponent
{
    [SerializeField] private PortalDisappearance _portalDisappearance;


    private void Start()
    {
        _portalDisappearance.Disappear();
    }


    void IRestartableComponent.Restart()
    {
        _portalDisappearance.ResetAnimation();
    }


    void IAfterRestartComponent.Restart()
    {
        _portalDisappearance.Disappear();
    }
}