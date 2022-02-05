using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(LightweightDiContainer))]
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LightweightDiContainer _diContainer;
    [SerializeField] private TransitionsConditions _transitionsConditions;
    [SerializeField] private Character _character;
    private IEnumerable<IMediator> _mediators;


    private void Awake()
    {        
        BindInstances();
        _diContainer.ResolveDependencies();
        InitializeMediators();
    }


    private void BindInstances()
    {
        var characterStatesPresenter = new CharacterStatesPresenter(_character);
        var transitionsPresenterFactory = new TransitionsPresenterFactory(characterStatesPresenter, _transitionsConditions);
        var transitionsPresenter = transitionsPresenterFactory.Create();
        
        _diContainer.RegisterInstance(characterStatesPresenter);
        _diContainer.RegisterInstance(transitionsPresenter);
    }


    private void InitializeMediators()
    {
        _mediators = FindObjectsOfType<MonoBehaviour>(true).OfType<IMediator>();
        _mediators.ForEach(mediator => mediator.Resolve());
    }
}