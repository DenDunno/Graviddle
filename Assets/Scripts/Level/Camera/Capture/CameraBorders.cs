using UnityEngine;


public class CameraBorders : MonoBehaviour
{
    [SerializeField] private int _levelHeight = 0;
    [SerializeField] private int _leftTile = 0;
    [SerializeField] private int _rightTile = 0;

    private readonly float _tileOffset = 0.5f;
    private float _rightCorner;


    private void Start()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        float width = height * Camera.main.aspect;

        _rightCorner = width / 2 + _leftTile - _tileOffset - 0.25f;
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, _rightCorner,  100);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, -_tileOffset, _levelHeight + _tileOffset);
    }
}
