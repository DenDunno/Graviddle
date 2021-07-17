using UnityEngine;


public class Stars : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private int _gold = 2;
    [SerializeField] private int _silver = 5;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private int _characterRotations = 0;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    public int GetStars()
    {
        if (_characterRotations <= _gold)
        {
            return 3;
        }

        else if (_characterRotations > _gold && _characterRotations <= _silver)
        {
            return 2;
        }

        return 1;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        ++_characterRotations;        
    }


    void IAfterRestartComponent.Restart()
    {
        _characterRotations = 0;
    }
}
