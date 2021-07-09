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
        Instantiate(this).ActivateTransit(scene);
    }


    private void ActivateTransit(int scene)
    {
        StartCoroutine(MakeTransition(scene));
    }


    private IEnumerator MakeTransition(int scene)
    {
        _scene = scene;
        Time.timeScale = 1f;

        Image transitionImage = (scene >= 0 && scene <= 2) ? _menuTransitionImage : _levelTransitionImage;
        _backstage = transitionImage.GetComponent<Backstage>();

        yield return StartCoroutine(_backstage.MakeFade(WaitWhileSceneLoading()));

        Destroy(gameObject);
    }


    private IEnumerator WaitWhileSceneLoading()
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(_scene);
        
        yield return new WaitWhile(() => sceneLoadingOperation.isDone == false);        
    }
}

