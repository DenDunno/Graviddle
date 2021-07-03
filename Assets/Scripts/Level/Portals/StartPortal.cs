using UnityEngine;


public class StartPortal :  MonoBehaviour, IRestartableComponent
{   
    private readonly PortalDisappearance _portalDisappearance  = new PortalDisappearance();


    private void Start()
    {
        StartCoroutine(_portalDisappearance.Disappear(transform));
    }


    void IRestartableComponent.Restart()
    {
        transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(_portalDisappearance.Disappear(transform));
    }
}