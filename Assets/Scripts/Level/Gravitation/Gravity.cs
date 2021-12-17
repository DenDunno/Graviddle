using UnityEngine;


public class Gravity : MonoBehaviour , IRestartableComponent
{
    [SerializeField] private SwipeHandler _swipeHandler = null;


    private void Start()
    {
        Physics2D.gravity = new Vector2(0, -1);
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        GravityData gravityData = GravityDataPresenter.GravityData[(int)gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
    }


    void IRestartableComponent.Restart()
    {
        OnGravityChanged(GravityDirection.Down);
    }
}