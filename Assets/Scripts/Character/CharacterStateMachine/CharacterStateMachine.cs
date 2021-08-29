using UnityEngine;


public class CharacterStateMachine : MonoBehaviour , IRestartableComponent
{
    [SerializeField] private CameraBorders _cameraBorders = null;
    private CharacterState _state;
    private CharacterStatesTransitions _characterStatesTransitions;


    private void Start()
    {
        _state = CharacterStates.IdleState;
        _characterStatesTransitions = new CharacterStatesTransitions(_state, SwitchState , _cameraBorders);
    }


    private void SwitchState(CharacterState newState)
    {
        _state = newState;
        _state.EnterState();
    }


    private void Update()
    {
        CharacterState newState = _state.Update();
        
        if (newState != _state)
        {
            SwitchState(newState);
        }
    }


    private void FixedUpdate()
    {
        _characterStatesTransitions.TryFall(transform);
        _characterStatesTransitions.TryDieByLevelBorders(transform);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _characterStatesTransitions.TryDieByObstacle(collision);
    }


    void IRestartableComponent.Restart()
    {
        enabled = true;
        SwitchState(CharacterStates.IdleState);
    }
}
