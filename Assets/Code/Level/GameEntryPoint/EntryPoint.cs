using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private Character _character;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private EditorInterfacesContainer _interfacesContainer;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private CameraMediator _cameraMediator;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    [SerializeField] private FinishPortal _finishPortal;
    [SerializeField] private LevelZoomCalculator _levelZoomCalculator;
    [SerializeField] private LaserTurret[] _laserTurrets;
    [SerializeField] private CharacterMoveDirection _characterMoveDirection;
    private ISubscriber[] _subscribers;
    private IUpdate[] _updatables;

    
    private void Awake()
    {
        RestartableComponents restartComponents = _interfacesContainer.GetRestartableComponents();
        var states = new CharacterStatesPresenter(_character.GetComponent<Animator>(), _characterMoveDirection);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(states, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();
        var restartEvent = new EventTransit();
        var gravity = new Gravity(_swipeHandler);
        var currentGravityData = new CurrentGravityData(_swipeHandler);
        var levelRestart = new LevelRestart(restartComponents, restartEvent.Invoke, states.DieState);
        var gravityRotations = new GravityRotation(currentGravityData, _interfacesContainer.GetTransformsWithGravityRotation());
        var analytics = new Analytics(states.WinState);
        
        _subscribers = new ISubscriber[] {levelRestart, gravity, currentGravityData, analytics};
        _updatables = new IUpdate[] {gravityRotations, _characterMoveDirection};

        analytics.Init();
        _laserTurrets.ForEach(laserTurret => laserTurret.Init(currentGravityData));
        _transitionsConditions.Init(_characterMoveDirection, restartEvent.CheckIfEventHappened);
        _characterMoveDirection.Init(currentGravityData);
        _character.Init(transitionsPresenter, states);
        _levelZoomCalculator.Init(currentGravityData);
        _uiStatesSwitcher.Init(states.DieState);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _winPanel.Init(states.WinState);
        _cameraMediator.Init();
    }


    private void OnEnable()
    {
        _subscribers.SubscribeForEach();
    }
    
    
    private void OnDisable()
    {
        _subscribers.UnsubscribeForEach();
    }
    

    private void Update()
    {
        _updatables.UpdateForEach();
    }
}