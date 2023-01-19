using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private LevelZoomCalculator _levelZoomCalculator;
    [SerializeField] private GravityRotation[] _gravityRotations;
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private CameraMediator _cameraMediator;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private FinishPortal _finishPortal;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private Character _character;
    [SerializeField] private WinPanel _winPanel;

    private void Awake()
    {
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        EventTransit restartEvent = new();
        Gravity gravity = new(_swipeHandler);
        CurrentGravityData currentGravityData = new(_swipeHandler);
        LevelRestart levelRestart = new(restartEvent.Invoke, states.DieState);
        
        _gravityRotations.ForEach(gravityRotation => gravityRotation.Init(currentGravityData));
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(currentGravityData));
        _transitionsConditions.Init(_characterMovementDirection, restartEvent.CheckIfEventHappened);
        _characterMovementDirection.Init(currentGravityData);
        _character.Init(transitionsPresenter, states);
        _levelZoomCalculator.Init(currentGravityData);
        _uiStatesSwitcher.Init(states.DieState);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _winPanel.Init(states.WinState);
        _cameraMediator.Init();
        
        SetDependencies(new object[] { levelRestart, gravity, currentGravityData, _characterMovementDirection});
    }
}