using UnityEngine;


public class MainMusicSpawner : MonoBehaviour
{
    [SerializeField] private MainMusic _music;


    private void Start() 
    {
        if (FindObjectOfType<MainMusic>() == null) 
        {
            DontDestroyOnLoad(Instantiate(_music));
        }
    }
}