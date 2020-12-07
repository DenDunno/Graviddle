using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private Object _music = null;

    private void Start() 
    {
        if (!FindObjectOfType<AudioSource>()) // выполнится при запуске игры
        {
            _music = Resources.Load("Prefabs/Menu/Music");
            DontDestroyOnLoad(Instantiate(_music));
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

}
