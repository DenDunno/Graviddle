using System.Collections;
using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private GameObject _winCanvas = null;
    [SerializeField] private GameObject _touchCanvas = null;
    [SerializeField] private GameObject _gameplayCanvas = null;

    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);


    public void FinishLevel()
    {
        _touchCanvas.SetActive(false);
        _gameplayCanvas.SetActive(false);
        _winCanvas.SetActive(true);

        StartCoroutine(Disappear());
    }


    private IEnumerator Disappear()
    {
        yield return StartCoroutine(_portalDisappearance.Disappear(transform));
        Destroy(gameObject);
    }
}