using System.Collections;
using UnityEngine;


public class StartPortal : MonoBehaviour, IRestartableComponent, IAfterRestartComponent
{   
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(1);
    private Coroutine _restartCoroutine;


    private IEnumerator Start()
    {
        yield return _restartCoroutine = StartCoroutine(_portalDisappearance.Disappear(transform));
        
        gameObject.SetActive(false);
    }


    void IRestartableComponent.Restart()
    {
        StopCoroutine(_restartCoroutine);

        gameObject.SetActive(true);
        transform.localScale = new Vector3(1, 1, 1);
    }


    void IAfterRestartComponent.Restart()
    {
        _restartCoroutine = StartCoroutine(Start());
    }
}