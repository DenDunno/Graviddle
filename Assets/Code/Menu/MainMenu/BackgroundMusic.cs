using UnityEngine;


public class BackgroundMusic : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}