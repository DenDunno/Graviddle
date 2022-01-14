using UnityEngine;


public class CharacterRotations : MonoBehaviour, IAfterRestartComponent
{
    [SerializeField] private CharacterRotationsUI _rotationsUI;
    [SerializeField] private SwipeHandler _swipeHandler;

    public int Rotations { get; private set; }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void UpdateValue(int rotations)
    {
        Rotations = rotations;
        _rotationsUI.UpdateRotationsUI(Rotations);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        UpdateValue(Rotations + 1);
    }


    void IAfterRestartComponent.Restart()
    {
        UpdateValue(0);
    }
}