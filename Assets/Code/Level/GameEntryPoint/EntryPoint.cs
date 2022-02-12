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
    [SerializeField] private MoveDirection _moveDirection;
    [SerializeField] private LevelZoomCalculator _levelZoomCalculator;
    private ISubscriber[] _subscribers;
    private IUpdatable[] _updatables;

    
    private void Awake()
    {
        RestartableComponents restartComponents = _interfacesContainer.GetRestartableComponents();
        var states = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(states, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();
        var characterRestartEvent = new CharacterRestartEvent();
        var levelRestart = new LevelRestart(restartComponents, states.DieState);
        var gravity = new Gravity(_swipeHandler);
        var currentGravityData = new CurrentGravityData(_swipeHandler);
        var gravityRotations = new GravityRotations(currentGravityData, _interfacesContainer.GravityRotations);
        
        _subscribers = new ISubscriber[] {levelRestart, gravity, currentGravityData};
        _updatables = new IUpdatable[] {gravityRotations};
        
        _character.Init(transitionsPresenter, states, characterRestartEvent);
        _transitionsConditions.Init(characterRestartEvent);
        _levelZoomCalculator.Init(currentGravityData);
        _uiStatesSwitcher.Init(states.DieState);
        _moveDirection.Init(currentGravityData);
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