using UnityEngine;


[RequireComponent(typeof(Camera))]
public class ScreenResolution : MonoBehaviour
{     
    private void Start()
    {
        Camera camera = GetComponent<Camera>();
        camera.aspect = 1280f / 720f;
    }
}
