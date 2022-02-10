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
    [SerializeField] private UIRestart _uiRestart;
    [SerializeField] private FinishPortal _finishPortal;
    

    private void Awake()
    {        
        var levelRestart = new LevelRestart(_interfacesContainer.RestartObjects, _interfacesContainer.AfterRestartObjects);
        var states = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(states, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();

        _character.Init(levelRestart, transitionsPresenter.GetTransition(states.FallState, states.IdleState), states);
        _transformsRestart.Init(_interfacesContainer.RestartableTransforms);
        _characterStateMachine.Init(states.IdleState, transitionsPresenter);
        _levelResultSave.Init(states.WinState);
        _finishPortal.Init(states.WinState);
        _uiRestart.Init(states.DieState);
        _winPanel.Init(states.WinState);
        _cameraMediator.Init();
    }
}