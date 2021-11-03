using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character = null;


    public override void InstallBindings()
    {
        var characterStates = new CharacterStates(_character);

        Container.Bind<CharacterStates>().FromInstance(characterStates).AsSingle();
    }
}
