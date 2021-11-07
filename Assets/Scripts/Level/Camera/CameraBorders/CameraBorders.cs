using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraBorders : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [SerializeField] private LevelSizeSettings _levelSizeSettings = null;
    private bool _isHorizontalClamping = true;


    private void Start()
    {
        _levelSizeSettings.EvaluateLevelSettings();
    }


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
        _levelSizeSettings.ClampCamera(ref cameraPosition , _isHorizontalClamping);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        _isHorizontalClamping = (int)gravityDirection % 2 == 0;
    }
}
