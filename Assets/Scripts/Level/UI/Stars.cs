using UnityEngine;


public class Stars : MonoBehaviour
{
    [SerializeField] private int _gold = 2;
    [SerializeField] private int _silver = 5;
    [SerializeField] private SwipeHandler _swipeHandler = null;

    private int _characterRotations = 0;

    
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


    private void Awake()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDestoy()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        ++_characterRotations;
        Debug.Log(_characterRotations);
    }
}
