using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    private Camera _camera;


    private void Start()
    {
        _camera = GetComponent<Camera>();
    }


    private void Update()
    {
        if (Input.touchCount == 2)
        {

        }
    }
}