using UnityEngine;


public class Gravity : MonoBehaviour, IRestart
{
    [SerializeField] private SwipeHandler _swipeHandler;


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
        GravityData gravityData = GravityDataPresenter.GravityData[gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
    }


    void IRestart.Restart()
    {
        OnGravityChanged(GravityDirection.Down);
    }
}