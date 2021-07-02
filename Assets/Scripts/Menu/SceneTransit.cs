using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Backstage))]
public class SceneTransit : MonoBehaviour
{
    [SerializeField] private Image _menuTransitionImage = null;
    [SerializeField] private Image _levelTransitionImage = null;

    private Backstage _backstage;
    private int _scene;


    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }


    public void SpawnTransit(int scene)
    {
        SceneTransit activeSceneTransit = Instantiate(this);
        activeSceneTransit.MakeTransition(scene);
    }


    private void MakeTransition(int scene)
    {
        _scene = scene;
        Time.timeScale = 1f;

        Image transitionImage = (scene >= 0 && scene <= 2) ? _menuTransitionImage : _levelTransitionImage;
        _backstage = transitionImage.GetComponent<Backstage>();

        StartCoroutine(_backstage.MakeFade(WaitWhileSceneLoading()));
        
        Destroy(gameObject);
    }


    private IEnumerator WaitWhileSceneLoading()
    {
        AsyncOperation loadingMenuScene = SceneManager.LoadSceneAsync(_scene);
        loadingMenuScene.allowSceneActivation = false;

        yield return new WaitUntil(() => loadingMenuScene.progress >= 0.9f);

        loadingMenuScene.allowSceneActivation = true;
    }
}

