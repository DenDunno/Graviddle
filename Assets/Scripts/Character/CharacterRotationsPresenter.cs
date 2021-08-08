using UnityEngine;


public class CharacterRotationsPresenter : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private SwipeHandler _swipeHandler = null;

    public int CharacterRotations { get; private set; } = 0;


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
        ++CharacterRotations;
    }


    void IAfterRestartComponent.Restart()
    {
        CharacterRotations = 0;
    }
}