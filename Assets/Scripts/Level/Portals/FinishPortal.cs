using System.Collections;
using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel = null;
    [SerializeField] private GameObject _touchCanvas = null;
    [SerializeField] private GameObject _pauseButton = null;

    private readonly PortalDisappearance _portalDisappearance = new PortalDisappearance(0.5f);


    public void FinishLevel()
    {
        _touchCanvas.SetActive(false);
        _pauseButton.SetActive(false);
        _winPanel.SetActive(true);

        StartCoroutine(Disappear());
    }


    private IEnumerator Disappear()
    {
        yield return StartCoroutine(_portalDisappearance.Disappear(transform));
        Destroy(gameObject);
    }
}