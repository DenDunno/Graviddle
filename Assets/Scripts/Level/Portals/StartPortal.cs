using UnityEngine;


[RequireComponent(typeof(PortalDisappearance))]
public class StartPortal :  MonoBehaviour, IRestartableObject
{   
    private readonly PortalDisappearance portalDisappearance  = new PortalDisappearance();


    private void Start()
    {
        StartCoroutine(portalDisappearance.Disappear(transform));
    }


    void IRestartableObject.Restart()
    {
        transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(portalDisappearance.Disappear(transform));
    }
}