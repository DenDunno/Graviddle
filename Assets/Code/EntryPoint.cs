using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private CharacterMovementDirection _characterMovementDirection;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private LevelStarsMediator _levelStarsMediator;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private GravityBox[] _gravityBoxes;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private LevelBorders _borders;
    [SerializeField] private Character _character;
    [SerializeField] private UI _ui;

    private void Awake()
    {
        CharacterStatesPresenter states = new(_character.GetComponent<Animator>(), _characterMovementDirection);
        TransitionsPresenterFactory transitionsPresenterFactory = new(states, _transitionsConditions);
        TransitionsPresenter transitionsPresenter = transitionsPresenterFactory.Create();
        CharacterGravityState characterGravityState = new(_swipeHandler);
        PollingEvent restartEvent = new();

        _transitionsConditions.Init(_characterMovementDirection, _character, _borders, restartEvent.CheckIfEventHappened);
        _character.Init(transitionsPresenter, states, _swipeHandler, characterGravityState);
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(characterGravityState));
        _cameraData.Init(_swipeHandler, _borders, characterGravityState, _character);
        _gravityBoxes.ForEach(gravityBox => gravityBox.Init(_swipeHandler));
        _characterMovementDirection.Init(characterGravityState);
        _levelStarsMediator.Resolve(characterGravityState);
        _levelResultSave.Init(states.WinState);
        _mainCamera.Init(_cameraData);

        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, states.DieState),
            _characterMovementDirection,
            new UIHandler(states, _character, _ui),
        });
    }
}