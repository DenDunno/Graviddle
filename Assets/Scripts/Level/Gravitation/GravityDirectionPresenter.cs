using UnityEngine;


public class GravityDirectionPresenter : MonoBehaviour
{
    [SerializeField] private GravityDirectionHandler _gravityDirectionHandler;

    public GravityDirection GravityDirection { get; private set; }
    public GravityData GravityData => GravityDataPresenter.GravityData[GravityDirection];
    

    private void OnEnable()
    {
        _gravityDirectionHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _gravityDirectionHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        GravityDirection = gravityDirection;
    }
}