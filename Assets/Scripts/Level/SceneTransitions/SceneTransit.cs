using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
        bool transitionToLevel = scene > 2;

        Image transitionImage = transitionToLevel ? _levelTransitionImage : _menuTransitionImage;
        _backstage = transitionImage.GetComponent<Backstage>();

        yield return StartCoroutine(_backstage.MakeTransition(WaitWhileSceneLoading()));

        if (transitionToLevel)
        {
            FindObjectOfType<UIStatesSwitcher>(true).gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }


    private IEnumerator WaitWhileSceneLoading()
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(_scene);
        
        yield return new WaitWhile(() => sceneLoadingOperation.isDone == false);        
    }
}