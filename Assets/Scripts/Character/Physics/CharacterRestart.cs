using System.Collections.Generic;
using UnityEngine;


public class CharacterRestart : MonoBehaviour, IRestart, IAfterRestart 
{
    private IEnumerable<IRestart> _restartComponents = new List<IRestart>();
    private IEnumerable<IAfterRestart> _afterRestartComponents = new List<IAfterRestart>();
    private readonly EventTransit _characterResurrected = new EventTransit();
    

    public void Init(IEnumerable<IRestart> restartComponents, IEnumerable<IAfterRestart> afterRestartComponents)
    {
        _restartComponents = restartComponents;
        _afterRestartComponents = afterRestartComponents;
    }


    public bool CheckRestart()
    {
        return _characterResurrected.CheckIfEventHappened();
    }


    void IRestart.Restart()
    {
        _characterResurrected.Invoke();
        _restartComponents.ForEach(beforeRestartComponent => beforeRestartComponent.Restart());
    }

    
    void IAfterRestart.Restart()
    {
        _afterRestartComponents.ForEach(afterRestartComponent => afterRestartComponent.Restart());
    }
}