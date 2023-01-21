using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private LevelZoomCalculator _levelZoomCalculator;
    [SerializeField] private GravityRotation[] _gravityRotations;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private CameraMediator _cameraMediator;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private FinishPortal _finishPortal;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Character _character;
    [SerializeField] private UI _ui;
    
    private void Awake()
    {
        PollingEvent restartEvent = new();
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        CurrentGravityData currentGravityData = new(_swipeHandler);

        _transitionsConditions.Init(_characterMovementDirection, restartEvent.CheckIfEventHappened);
        _gravityRotations.ForEach(gravityRotation => gravityRotation.Init(currentGravityData));
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(currentGravityData));
        _characterMovementDirection.Init(currentGravityData);
        _character.Init(transitionsPresenter, states);
        _levelZoomCalculator.Init(currentGravityData);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _cameraMediator.Init();
        
        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, states.DieState), 
            new Gravity(_swipeHandler),
            new UIHandler(states, _ui),
            currentGravityData, 
            _characterMovementDirection
        });
    }
}