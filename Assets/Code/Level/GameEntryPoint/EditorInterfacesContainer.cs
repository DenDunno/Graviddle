using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// buffer between editor and playmode
public class EditorInterfacesContainer : MonoBehaviour
{
    [SerializeField] private List<MonoBehaviour> _restartable;
    [SerializeField] private List<MonoBehaviour> _afterRestartable;
    [SerializeField] private List<MonoBehaviour> _restartableTransforms;
    [SerializeField] private List<MonoBehaviour> _gravityRotations;
    
    public IEnumerable<Transform> GravityRotations => _gravityRotations.Select(restartable => restartable.transform);


    public void FillContainers()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);

        _afterRestartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IAfterRestart).ToList();
        _restartable = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestart).ToList();
        _restartableTransforms = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IRestartableTransform).ToList();
        _gravityRotations = allMonoBehaviours.Where(monoBehaviour => monoBehaviour is IGravityRotation).ToList();
    }


    public RestartableComponents GetRestartableComponents()
    {
        IEnumerable<IRestart> restartComponents = _restartable.Cast<IRestart>();
        IEnumerable<IAfterRestart> afterRestartComponents = _afterRestartable.Cast<IAfterRestart>();
        List<RestartableTransform> restartTransforms = new List<RestartableTransform>();

        foreach (MonoBehaviour restartableTransform in _restartableTransforms)
        {
            restartTransforms.Add(new RestartableTransform(restartableTransform.transform));
        }

        return new RestartableComponents(restartComponents, afterRestartComponents, restartTransforms);
    }
}