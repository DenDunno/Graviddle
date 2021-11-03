using UnityEngine;
using Zenject;


[RequireComponent(typeof(Collider2D))]
public class FinishPortalCollision : MonoBehaviour , IRestartableComponent
{
    [Inject] private readonly CharacterStates _characterStates = null;
    private Collider2D _collider;


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }


    private void OnEnable()
    {
        _characterStates.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _characterStates.DieState.CharacterDied -= OnCharacterDied;
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