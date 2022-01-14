using UnityEngine;


public class GravityDirectionPresenter : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler;

    public GravityDirection GravityDirection { get; private set; }


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
        GravityDirection = gravityDirection;
    }
}