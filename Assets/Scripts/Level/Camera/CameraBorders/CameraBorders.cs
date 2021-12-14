using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CameraBorders : MonoBehaviour
{
    [SerializeField] private LevelSizeSettings _levelSizeSettings = null;
    [SerializeField] private GravityDirectionPresenter _gravityDirectionPresenter = null;


    private void Start()
    {
        _levelSizeSettings.EvaluateLevelSettings();
    }


    public void ClampCamera(ref Vector3 cameraPosition)
    {
        _levelSizeSettings.ClampCamera(ref cameraPosition , _gravityDirectionPresenter.IsHorizontalClamping);
    }
}