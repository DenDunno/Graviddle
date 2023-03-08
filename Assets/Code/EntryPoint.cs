using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private LevelStarsMediator _levelStarsMediator;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private GravityBox[] _gravityBoxes;
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private Character _character;
    [SerializeField] private UI _ui;

    private void Awake()
    {
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        GravityState characterGravityState = new(_swipeHandler);
        PollingEvent restartEvent = new();

        _transitionsConditions.Init(_characterMovementDirection, restartEvent.CheckIfEventHappened);
        _character.Init(transitionsPresenter, states, _swipeHandler, characterGravityState);
        _mainCamera.Init(characterGravityState, _swipeHandler, _levelBorders, _character);
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(characterGravityState));
        _gravityBoxes.ForEach(gravityBox => gravityBox.Init(_swipeHandler));
        _characterMovementDirection.Init(characterGravityState);
        _levelResultSave.Init(states.WinState);
        _levelStarsMediator.Resolve(characterGravityState);

        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, states.DieState),
            _characterMovementDirection,
            new UIHandler(states, _ui),
        });
    }
}