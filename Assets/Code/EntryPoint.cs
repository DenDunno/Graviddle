using UnityEngine;

public class EntryPoint : MonoBehaviourWrapper
{
    [SerializeField] private LevelStarsMediator _levelStarsMediator;
    [SerializeField] private CharacterData _characterData;
    [SerializeField] private GravityBox[] _gravityBoxes;
    [SerializeField] private CameraData _cameraData;
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private LevelBorders _borders;
    [SerializeField] private Character _character;
    [SerializeField] private Reward _reward;
    [SerializeField] private UI _ui;

    private void Awake()
    {
        PollingEvent restartEvent = new();

        _characterData.Init(_character, _borders, restartEvent.CheckIfEventHappened);
        _cameraData.Init(_characterData.SwipeHandler, _borders, _characterData.GravityState, _character);

        _mainCamera.Init(_cameraData);
        _character.Init(_characterData);
        _levelStarsMediator.Resolve(_characterData.GravityState);
        _gravityBoxes.ForEach(gravityBox => gravityBox.Init(_characterData.SwipeHandler));

        SetDependencies(new IUnityCallback[]
        {
            new LevelRestart(restartEvent.Invoke, _characterData.States.DieState),
            new UIHandler(_characterData.States, _character, _ui),
            new LevelResultSave(_reward, _characterData.States.WinState)
        });
    }
}