using UnityEngine;
using Zenject;


public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private Character _character = null;
    [SerializeField] private CameraBorders _cameraBorders = null;
    private TransitionsConditions _conditions;


    public override void InstallBindings()
    {
        _conditions = new TransitionsConditions(_character, _cameraBorders);
        var characterStatesPresenter = new CharacterStatesPresenter(_character);
        var transitionsPresenter = new TransitionsPresenter();

        FillTransitionsPresenter(transitionsPresenter, characterStatesPresenter);

        Container.Bind<CharacterStatesPresenter>().FromInstance(characterStatesPresenter).AsSingle();
        Container.Bind<TransitionsPresenter>().FromInstance(transitionsPresenter).AsSingle();
    }


    private void FillTransitionsPresenter(TransitionsPresenter transitionsPresenter, CharacterStatesPresenter states)
    {
        transitionsPresenter.AddTransition(states.IdleState, _conditions.CheckDeathByObstacle, states.DieState);
        transitionsPresenter.AddTransition(states.IdleState, _conditions.CheckIfFall , states.FallState);
        transitionsPresenter.AddTransition(states.IdleState, _conditions.CheckIfRun , states.RunState);

        transitionsPresenter.AddTransition(states.RunState, _conditions.CheckDeathByObstacle, states.DieState);
        transitionsPresenter.AddTransition(states.RunState, _conditions.CheckIfFall , states.FallState);
        transitionsPresenter.AddTransition(states.RunState, _conditions.CheckIfIdle , states.IdleState);
        transitionsPresenter.AddTransition(states.RunState, _conditions.CheckWin, states.WinState);
        
        transitionsPresenter.AddTransition(states.FallState, _conditions.CheckDeathByObstacle, states.DieState);
        transitionsPresenter.AddTransition(states.FallState, _conditions.CheckDeathByLevelBorders , states.DieState);
        transitionsPresenter.AddTransition(states.FallState, _conditions.CheckIfGrounded , states.IdleState);
        transitionsPresenter.AddTransition(states.FallState, _conditions.CheckWin, states.WinState);
    }
}
