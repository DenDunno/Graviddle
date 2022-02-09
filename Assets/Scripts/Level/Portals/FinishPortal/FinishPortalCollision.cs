using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class FinishPortalCollision : MonoBehaviour, IRestart
{
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    private Collider2D _collider;


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }


    private void OnEnable()
    {
        _characterStatesPresenter.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        _collider.enabled = false;
    }


    void IRestart.Restart()
    {
        _collider.enabled = true;
    }
}