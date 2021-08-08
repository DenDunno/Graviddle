using UnityEngine;


[RequireComponent(typeof(Camera))]
public class ScreenResolution : MonoBehaviour
{     
    private void Start()
    {
        GetComponent<Camera>().aspect = 1280f / 720f;
    }
}
