using UnityEngine;


public class MainMenu : MonoBehaviour
{
    private void Start() 
    {
        if (FindObjectOfType<AudioSource>() == null) 
        {
            Object music = Resources.Load("Music");
            DontDestroyOnLoad(Instantiate(music));
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}
