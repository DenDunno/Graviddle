using UnityEngine;


public class CurrentGravityData : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler;

    public GravityData Data { get; private set; }


    void ISubscriber.Subscribe()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }

    
    void ISubscriber.Unsubscribe()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }

    
    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        Data = GravityDataPresenter.GravityData[gravityDirection];
    }
}