using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelButton : MonoBehaviour
{
    private void Start()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int scenesCount = SceneManager.sceneCountInBuildSettings;

        if (activeSceneIndex == scenesCount - 1)
        {
            gameObject.SetActive(false);
        }
    }
}