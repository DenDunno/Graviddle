using UnityEngine;


public class CharacterRotations : MonoBehaviour , IAfterRestartComponent
{
    public int Rotations { get; private set; } = 0;

    [SerializeField] private CharacterRotationsUI _rotationsUI = null;
    [SerializeField] private SwipeHandler _swipeHandler = null;


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
        ++Rotations;
        _rotationsUI.UpdateValue(Rotations);
    }


    void IAfterRestartComponent.Restart()
    {
        Rotations = 0;
    }
}