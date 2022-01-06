using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character = null;
    [SerializeField] private LevelBorders _levelBorders = null;


    public override void InstallBindings()
    {
        var conditions = new TransitionsConditions(_character, _levelBorders);
        var characterStates = new CharacterStatesPresenter(_character);

        TransitionsPresenter updateTransitions = UpdateTransitionsFactory.Create(conditions, characterStates);
        TransitionsPresenter eventTransitions = UpdateTransitionsFactory.Create(conditions, characterStates);

        TransitionsPresenter[] transitionsPresenters = { eventTransitions, updateTransitions };

        var transitionCheck = new TransitionCheck(transitionsPresenters);

        Container.Bind<CharacterStatesPresenter>().FromInstance(characterStates).AsSingle();
        Container.Bind<TransitionCheck>().FromInstance(transitionCheck).AsSingle();
    }
}