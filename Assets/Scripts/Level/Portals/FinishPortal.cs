using UnityEngine;


public class FinishPortal : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel = null;
    [SerializeField] private GameObject _touchCanvas = null;
    [SerializeField] private GameObject _pauseButton = null;


    private void Start()
    {
        ToggleTimeScale(1f);
    }


    public void FinishLevel()
    {
        _touchCanvas.SetActive(false);
        _pauseButton.SetActive(false);
        _winPanel.SetActive(true);

        ToggleTimeScale(0.5f);
    }


    private void ToggleTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}