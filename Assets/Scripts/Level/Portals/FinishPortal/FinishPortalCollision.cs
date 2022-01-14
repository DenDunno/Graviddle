using UnityEngine;
using Zenject;


[RequireComponent(typeof(Collider2D))]
public class FinishPortalCollision : MonoBehaviour, IRestartableComponent
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
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


    void IRestartableComponent.Restart()
    {
        _collider.enabled = true;
    }
}