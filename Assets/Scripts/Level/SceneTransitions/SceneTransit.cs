using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTransit : MonoBehaviour
{
    [SerializeField] private Image _menuTransitionImage = null;
    [SerializeField] private Image _levelTransitionImage = null;

    private readonly int _menuScenesCount = 2;


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
        bool transitionToLevel = scene > _menuScenesCount;

        Image transitionImage = transitionToLevel ? _levelTransitionImage : _menuTransitionImage;
        var backstage = transitionImage.GetComponent<Backstage>();

        yield return StartCoroutine(backstage.MakeTransition(WaitWhileSceneLoading(scene)));

        if (transitionToLevel)
        {
            FindObjectOfType<UIStatesSwitcher>(true).gameObject.SetActive(true);
        }

        Destroy(gameObject);
    }


    private IEnumerator WaitWhileSceneLoading(int scene)
    {
        AsyncOperation sceneLoadingOperation = SceneManager.LoadSceneAsync(scene);
        
        yield return new WaitWhile(() => sceneLoadingOperation.isDone == false);        
    }
}