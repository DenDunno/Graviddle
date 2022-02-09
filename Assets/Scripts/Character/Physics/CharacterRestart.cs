using System.Collections.Generic;
using UnityEngine;


public class CharacterRestart : MonoBehaviour, IRestart, IAfterRestart 
{
    private readonly List<IRestart> _beforeRestartComponents = new List<IRestart>();
    private readonly List<IAfterRestart> _afterRestartComponents = new List<IAfterRestart>();


    public void Init(List<object> dependencies)
    {
        foreach (object dependency in dependencies)
        {
            if (dependency is IRestart restart)
            {
                _beforeRestartComponents.Add(restart);
            }
        }
    }


    void IRestart.Restart()
    {
        _beforeRestartComponents.ForEach(beforeRestartComponent => beforeRestartComponent.Restart());
    }

    
    void IAfterRestart.Restart()
    {
        _afterRestartComponents.ForEach(afterRestartComponent => afterRestartComponent.Restart());
    }
}