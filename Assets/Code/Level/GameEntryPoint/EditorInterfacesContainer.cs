using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// buffer between editor and playmode
public class EditorInterfacesContainer : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _restartable;
    [SerializeField] private List<MonoBehaviour> _afterRestartable;


    public void FillContainers()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);
        
        _afterRestartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IAfterRestart).ToList();
        _restartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestart).ToList();
    }


    public RestartableComponents GetRestartableComponents()
    {
        IEnumerable<IRestart> restartComponents = _restartable.Cast<IRestart>();
        IEnumerable<IAfterRestart> afterRestartComponents = _afterRestartable.Cast<IAfterRestart>();

        return new RestartableComponents(restartComponents, afterRestartComponents);
    }
}