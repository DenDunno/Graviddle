using UnityEngine;


public class CameraBorders : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    [SerializeField] private float _levelWidth = 10;
    [SerializeField] private float _levelHeight = 10;

    private readonly float _horizontalOffset = 4.11f;
    private bool _isHorizontalClamping = true;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }    


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        float horizontalOffset = _isHorizontalClamping ? 0 : _horizontalOffset;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, -0.5f - horizontalOffset, _levelWidth + horizontalOffset);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, -0.5f + horizontalOffset, _levelHeight - horizontalOffset);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _isHorizontalClamping = (int)gravityDirection % 2 == 0;
    }
}
