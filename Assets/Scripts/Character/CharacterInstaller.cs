using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character = null;


    public override void InstallBindings()
    {
        var characterStates = new CharacterStatesPresenter(_character);

        Container.Bind<CharacterStatesPresenter>().FromInstance(characterStates).AsSingle();
    }
}
