using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTransit : MonoBehaviour
{
    [SerializeField] private Image _menuTransitionImage = null;
    [SerializeField] private Image _levelTransitionImage = null;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void SpawnTransit(int scene)
    {
        Instantiate(this).ActivateTransit(scene);
    }


    public void ActivateTransit(int scene)
    {
        StartCoroutine(MakeTransition(scene));
    }


    private IEnumerator MakeTransition(int scene)
    {
        Image transitionImage = scene >= 0 && scene <= 2 ? _menuTransitionImage : _levelTransitionImage;
        // Переход в меню или между уровнями

        Time.timeScale = 1f;

        AsyncOperation loadingMenuScene = SceneManager.LoadSceneAsync(scene);
        loadingMenuScene.allowSceneActivation = false;

        yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(2, true, (result) => { transitionImage.color = result; }));

        yield return new WaitUntil(() => loadingMenuScene.progress >= 0.9f);
        loadingMenuScene.allowSceneActivation = true;

        yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(-2, false, (result) => { transitionImage.color = result; }));

        Destroy(gameObject);
    }
}

