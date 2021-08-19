using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _music = null;


    private void Start() 
    {
        if (FindObjectOfType<AudioSource>() == null) 
        {
            DontDestroyOnLoad(Instantiate(_music));
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}
