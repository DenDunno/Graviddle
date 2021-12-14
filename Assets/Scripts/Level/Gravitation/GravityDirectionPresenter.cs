using UnityEngine;


public class GravityDirectionPresenter : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    public GravityDirection GravityDirection { get; private set; }

    public bool IsHorizontalClamping => GravityDirection == GravityDirection.Down ||
                                        GravityDirection == GravityDirection.Up;


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