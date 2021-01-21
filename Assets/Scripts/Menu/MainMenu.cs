using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Start() 
    {
        if (FindObjectOfType<AudioSource>() == null) // выполнится при запуске игры
        {
            Object _music = Resources.Load("Prefabs/Menu/Music");
            DontDestroyOnLoad(Instantiate(_music));
        }
    }


    public void Exit()
    {
        Application.Quit();
    }

}
