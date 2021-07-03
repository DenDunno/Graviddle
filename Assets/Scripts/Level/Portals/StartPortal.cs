using System.Collections;
using UnityEngine;


public class StartPortal :  MonoBehaviour, IRestartableComponent
{   
    private readonly PortalDisappearance _portalDisappearance  = new PortalDisappearance();


    private IEnumerator Start()
    {
        yield return StartCoroutine(_portalDisappearance.Disappear(transform));
        gameObject.SetActive(false);
    }


    void IRestartableComponent.Restart()
    {
        gameObject.SetActive(true);
        transform.localScale = new Vector3(1, 1, 1);

        StartCoroutine(Start());
    }
}