using UnityEngine;


public class ScreenResolution : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;


    private void Start()
    {
        _mainCamera.aspect = 1280f / 720f;
    }
}
