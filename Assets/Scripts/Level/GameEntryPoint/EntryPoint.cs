using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private Character _character;
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private EditorInterfacesContainer _interfacesContainer;
    [SerializeField] private TransformsRestart _transformsRestart;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private CameraMediator _cameraMediator;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    [SerializeField] private FinishPortal _finishPortal;
    private ISubscriber[] _subscribers;

    
    private void Awake()
    {
        var states = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(states, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();
        var characterRestartEvent = new CharacterRestartEvent();
        var levelRestart = new LevelRestart(_interfacesContainer.RestartObjects, _interfacesContainer.AfterRestartObjects, states.DieState);
        var gravity = new Gravity(_swipeHandler);
        
        _subscribers = new ISubscriber[] {levelRestart, gravity};
        
        _character.Init(transitionsPresenter, states, characterRestartEvent);
        _transformsRestart.Init(_interfacesContainer.RestartableTransforms);
        _transitionsConditions.Init(characterRestartEvent);
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
}