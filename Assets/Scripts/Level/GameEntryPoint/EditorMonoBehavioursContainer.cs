using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

// buffer between editor and playmode
public class EditorMonoBehavioursContainer : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _restartable;
    [SerializeField] private List<MonoBehaviour> _afterRestartable;
    [SerializeField] private List<MonoBehaviour> _mediators;
    [SerializeField] private List<MonoBehaviour> _objectsWithDependencies;
    [SerializeField] private List<MonoBehaviour> _restartableTransforms;

    public IEnumerable<IRestart> RestartObjects => _restartable.Cast<IRestart>();
    public IEnumerable<IAfterRestart> AfterRestartObjects => _afterRestartable.Cast<IAfterRestart>();
    public IEnumerable<IMediator> Mediators => _mediators.Cast<IMediator>();
    public IEnumerable<MonoBehaviour> ObjectsWithDependencies => _objectsWithDependencies;
    public IEnumerable<Transform> RestartableTransforms => _restartableTransforms.Select(restartable => restartable.transform);

    
    public void FillContainers()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);
        
        _restartable.Clear();
        _afterRestartable.Clear();
        _mediators.Clear();
        _objectsWithDependencies.Clear();
        _restartableTransforms.Clear();
        
        foreach (MonoBehaviour monoBehaviour in allMonoBehaviours)
        {
            _afterRestartable.TryAddToList<IAfterRestart, MonoBehaviour>(monoBehaviour);
            _restartable.TryAddToList<IRestart, MonoBehaviour>(monoBehaviour);
            _mediators.TryAddToList<IMediator, MonoBehaviour>(monoBehaviour);
            _restartableTransforms.TryAddToList<IRestartableTransform, MonoBehaviour>(monoBehaviour);
            
            if (CheckIfHasDependency(monoBehaviour))
            {
                _objectsWithDependencies.Add(monoBehaviour);
            }
        }

        EditorUtility.SetDirty(this);
    }
    
    
    private bool CheckIfHasDependency(MonoBehaviour monoBehaviour)
    {
        IEnumerable<FieldInfo> fieldsToInject = monoBehaviour.GetType().GetFieldsToInject();
        return fieldsToInject.Count() != 0;
    }
}