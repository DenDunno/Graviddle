using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private LevelStarsMediator _levelStarsMediator;
    [SerializeField] private GravityRotation[] _gravityRotations;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private FinishPortal _finishPortal;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private LevelBorders _levelBorders;
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private Character _character;
    [SerializeField] private UI _ui;

    private void Awake()
    {
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        CurrentGravityData currentGravityData = new(_swipeHandler);
        PollingEvent restartEvent = new();

        _transitionsConditions.Init(_characterMovementDirection, restartEvent.CheckIfEventHappened);
        _gravityRotations.ForEach(gravityRotation => gravityRotation.Init(currentGravityData));
        _mainCamera.Init(currentGravityData, _swipeHandler, _levelBorders, _character);
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(currentGravityData));
        _character.Init(transitionsPresenter, states, _swipeHandler);
        _characterMovementDirection.Init(currentGravityData);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _levelStarsMediator.Resolve();

        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, states.DieState),
            _characterMovementDirection,
            new UIHandler(states, _ui),
            currentGravityData,
        });
    }
}