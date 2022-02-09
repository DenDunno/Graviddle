using UnityEngine;


[RequireComponent(typeof(LightweightDiContainer))]
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LightweightDiContainer _diContainer;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private Character _character;
    [SerializeField] private EditorMonoBehavioursContainer _monoBehavioursContainer;

    
    private void Awake()
    {        
        BindInstances();
        _diContainer.ResolveDependencies(_monoBehavioursContainer.ObjectsWithDependencies);
        _monoBehavioursContainer.Mediators.ForEach(mediator => mediator.Resolve());
    }


    private void BindInstances()
    {
        var levelRestart = new LevelRestart(_monoBehavioursContainer.RestartObjects, _monoBehavioursContainer.AfterRestartObjects);
        var characterStatesPresenter = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(characterStatesPresenter, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();

        _diContainer.RegisterInstance(characterStatesPresenter);
        _diContainer.RegisterInstance(transitionsPresenter);
        _diContainer.RegisterInstance(levelRestart);
    }
}