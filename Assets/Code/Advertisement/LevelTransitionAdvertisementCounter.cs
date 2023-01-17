using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionAdvertisementCounter : MonoBehaviour
{
    private readonly LevelTransitionAdvertisement _levelTransitionAdvertisement = new LevelTransitionAdvertisement(); 
    private const int _levelBeforeAdvertisement = 3;
    private const int _menuScenes = 2;
    private static int _counter;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += TryShowAdvertisement;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= TryShowAdvertisement;
    }
    
    private void TryShowAdvertisement(Scene sceneFrom, Scene sceneTo)
    {
        int activeScene = sceneTo.buildIndex;

        if (activeScene > _menuScenes)
        {
            _counter++;

            if (_counter == _levelBeforeAdvertisement)
            {
                _counter = 0;
                _levelTransitionAdvertisement.Show();
            }
        }
    }
}