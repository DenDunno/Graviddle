using System.Collections.Generic;
using UnityEngine;

public class TransformsRestart : MonoBehaviour, IRestart
{
    private readonly List<RestartableTransform> _restartableTransforms = new List<RestartableTransform>();

    public void Init(IEnumerable<Transform> transformsToBeRestarted)
    {
        foreach (Transform restartableTransform in transformsToBeRestarted)
        {
            _restartableTransforms.Add(new RestartableTransform(restartableTransform));
        }
    }
    
    void IRestart.Restart()
    {
        _restartableTransforms.ForEach(restartableTransform => restartableTransform.Restart());
    }
}