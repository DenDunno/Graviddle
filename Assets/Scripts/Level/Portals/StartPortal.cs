using System.Collections;
using UnityEngine;


public class StartPortal :  MonoBehaviour, IAfterRestartComponent
{   
    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(1);
    private Coroutine _restartCoroutine;


    private IEnumerator Start()
    {
        yield return _restartCoroutine = StartCoroutine(_portalDisappearance.Disappear(transform));
        
        gameObject.SetActive(false);
    }


    void IAfterRestartComponent.Restart()
    {
        StopCoroutine(_restartCoroutine);

        gameObject.SetActive(true);
        transform.localScale = new Vector3(1, 1, 1);

        _restartCoroutine = StartCoroutine(Start());
    }
}