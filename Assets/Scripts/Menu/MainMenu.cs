using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMusic _music = null;


    private void Start() 
    {
        if (FindObjectOfType<MainMusic>() == null) 
        {
            DontDestroyOnLoad(Instantiate(_music));
        }
    }


    public void Exit()
    {
        Application.Quit();
    }
}
