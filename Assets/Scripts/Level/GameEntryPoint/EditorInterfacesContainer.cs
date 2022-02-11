using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// buffer between editor and playmode
public class EditorInterfacesContainer : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _restartable;
    [SerializeField] private List<MonoBehaviour> _afterRestartable;
    [SerializeField] private List<MonoBehaviour> _restartableTransforms;

    public IEnumerable<IRestart> RestartObjects => _restartable.Cast<IRestart>();
    public IEnumerable<IAfterRestart> AfterRestartObjects => _afterRestartable.Cast<IAfterRestart>();
    public IEnumerable<Transform> RestartableTransforms => _restartableTransforms.Select(restartable => restartable.transform);

    
    public void FillContainers()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);

        _afterRestartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IAfterRestart).ToList();
        _restartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestart).ToList();
        _restartableTransforms = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestartableTransform).ToList();
    }
}