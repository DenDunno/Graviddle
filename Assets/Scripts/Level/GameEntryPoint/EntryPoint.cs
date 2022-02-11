using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private Character _character;
    [SerializeField] private EditorInterfacesContainer _interfacesContainer;
    [SerializeField] private TransformsRestart _transformsRestart;
    [SerializeField] private WinPanel _winPanel;
    [SerializeField] private CharacterStateMachine _characterStateMachine;
    [SerializeField] private CameraMediator _cameraMediator;
    [SerializeField] private LevelResultSave _levelResultSave;
    [SerializeField] private UIStatesSwitcher _uiStatesSwitcher;
    [SerializeField] private FinishPortal _finishPortal;

    
    private void Awake()
    {
        var states = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(states, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();
        var characterRestartEvent = new CharacterRestartEvent();
        var fallToIdleTransition = transitionsPresenter.GetTransition(states.FallState, states.IdleState);
        var levelRestart = new LevelRestart(_interfacesContainer.RestartObjects, _interfacesContainer.AfterRestartObjects, states.DieState);

        _character.Init(fallToIdleTransition, states, characterRestartEvent, levelRestart);
        _transformsRestart.Init(_interfacesContainer.RestartableTransforms);
        _characterStateMachine.Init(states.IdleState, transitionsPresenter);
        _transitionsConditions.Init(characterRestartEvent);
        _uiStatesSwitcher.Init(states.DieState);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _winPanel.Init(states.WinState);
        _cameraMediator.Init();
    }
}