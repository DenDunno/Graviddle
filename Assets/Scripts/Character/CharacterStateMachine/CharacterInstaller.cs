using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character = null;
    [SerializeField] private CharacterStatesTransitionsFactory _characterStatesTransitionsFactory = null;
    

    public override void InstallBindings()
    {
        var characterStates = new CharacterStatesPresenter(_character);

        _characterStatesTransitionsFactory.Init(_character, characterStates);

        var transitionsPresenter = _characterStatesTransitionsFactory.Create();

        Container.Bind<CharacterStatesPresenter>().FromInstance(characterStates).AsSingle();
        Container.Bind<CharacterStateTransitions>().FromInstance(transitionsPresenter).AsSingle();
    }
}