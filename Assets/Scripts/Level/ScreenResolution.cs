using UnityEngine;


[RequireComponent(typeof(Camera))]
public class ScreenResolution : MonoBehaviour
{
    private Camera _camera;


    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }


    private void Update()
    {
        _camera.aspect = 1280f / 720f;
    }
}
