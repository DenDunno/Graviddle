using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Transit : MonoBehaviour
{
    [SerializeField]
    private Image menuTransitionImage = null;

    [SerializeField]
    private Image levelTransitionImage = null;


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
        Image transition_image = scene >= 0 && scene <= 2 ? menuTransitionImage : levelTransitionImage;
        // Переход в меню или между уровнями

        Time.timeScale = 1f;

        AsyncOperation loading_menu_scene = SceneManager.LoadSceneAsync(scene);
        loading_menu_scene.allowSceneActivation = false;

        yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(2, false, transition_image));

        yield return new WaitUntil(() => loading_menu_scene.progress >= 0.9f);
        loading_menu_scene.allowSceneActivation = true;

        yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(-2, true, transition_image));

        Destroy(gameObject);
    }
}

