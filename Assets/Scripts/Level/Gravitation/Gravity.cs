using UnityEngine;


public class Gravity : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private GravityDirectionHandler _gravityDirectionHandler;


    private void Start()
    {
        Physics2D.gravity = new Vector2(0, -1);
    }


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
        GravityData gravityData = GravityDataPresenter.GravityData[gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
    }


    void IRestartableComponent.Restart()
    {
        OnGravityChanged(GravityDirection.Down);
    }
}