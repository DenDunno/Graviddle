using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character;
    [SerializeField] private CharacterStatesTransitionsFactory _characterStatesTransitionsFactory;
    

    public override void InstallBindings()
    {
        var characterStates = new CharacterStatesPresenter(_character);

        _characterStatesTransitionsFactory.Init(_character, characterStates);

        CharacterStateTransitions characterStateTransitions = _characterStatesTransitionsFactory.Create();

        Container.Bind<CharacterStatesPresenter>().FromInstance(characterStates).AsSingle();
        Container.Bind<CharacterStateTransitions>().FromInstance(characterStateTransitions).AsSingle();
    }
}