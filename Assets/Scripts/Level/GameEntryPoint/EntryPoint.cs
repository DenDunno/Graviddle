using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LightweightDiContainer))]
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private LightweightDiContainer _diContainer;
    [SerializeField] private Character _character;
    [SerializeField] private CharacterStatesTransitionsFactory _characterStatesTransitionsFactory;
    private readonly List<object> _instances = new List<object>();

    
    private void Start()
    {
        ConstructInstances();
        RegisterTypes();
        _diContainer.ResolveDependencies();
    }

    
    private void ConstructInstances()
    {
        var characterStates = new CharacterStatesPresenter(_character);
        _characterStatesTransitionsFactory.Init(_character, characterStates);
        CharacterStateTransitions characterStateTransitions = _characterStatesTransitionsFactory.Create();
        
        _instances.Add(characterStates);
        _instances.Add(characterStateTransitions);
    }
    
    
    private void RegisterTypes()
    {
        foreach (object instance in _instances)
        {
            _diContainer.RegisterTypeWithInstance(instance);
        }
    }
}