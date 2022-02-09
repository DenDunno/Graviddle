using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// buffer between editor and runtime
public class EditorMonoBehavioursContainer : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _restartable;
    [SerializeField] private List<MonoBehaviour> _afterRestartable;
    [SerializeField] private List<MonoBehaviour> _mediators;
    [SerializeField] private List<MonoBehaviour> _objectsWithDependencies;

    public IEnumerable<IRestart> RestartObjects => _restartable.OfType<IRestart>();
    public IEnumerable<IAfterRestart> AfterRestartObjects => _afterRestartable.OfType<IAfterRestart>();
    public IEnumerable<IMediator> Mediators => _mediators.OfType<IMediator>();
    public IEnumerable<MonoBehaviour> ObjectsWithDependencies => _objectsWithDependencies;


    public void FillContainers()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);

        foreach (MonoBehaviour monoBehaviour in allMonoBehaviours)
        {
            TryAddToList(monoBehaviour, _restartable);
            TryAddToList(monoBehaviour, _afterRestartable);
            TryAddToList(monoBehaviour, _mediators);
        }
    }


    private void TryAddToList<T>(MonoBehaviour monoBehaviour, ICollection<T> list)
    {
        if (monoBehaviour is T custedInterface)
        {
            list.Add(custedInterface);
        }
    }
}