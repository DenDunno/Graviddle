using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MonoBehaviourWrapper : MonoBehaviour, IRestart, IAfterRestart
{
    private IEnumerable<IAfterRestart> _afterRestartComponents;
    private IEnumerable<IRestart> _restartComponents;
    private IEnumerable<IFixedUpdate> _fixedUpdates;
    private IEnumerable<ISubscriber> _subscribers;
    private IEnumerable<ILateUpdate> _lateUpdates;
    private IEnumerable<IUpdate> _updates;

    protected void SetDependencies(IUnityCallback[] dependencies)
    {
        dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Initialize());
        _afterRestartComponents = dependencies.OfType<IAfterRestart>();
        _restartComponents = dependencies.OfType<IRestart>();
        _fixedUpdates = dependencies.OfType<IFixedUpdate>();
        _subscribers = dependencies.OfType<ISubscriber>();
        _lateUpdates = dependencies.OfType<ILateUpdate>(); 
        _updates = dependencies.OfType<IUpdate>();
    }

    private void OnEnable()
    {
        _subscribers.SubscribeForEach();
    }

    private void OnDisable()
    {
        _subscribers.UnsubscribeForEach();
    }

    private void FixedUpdate()
    {
        _fixedUpdates.FixedUpdateForEach();
    }

    private void Update()
    {
        _updates.UpdateForEach();
    }

    private void LateUpdate()
    {
        _lateUpdates.LateUpdateForEach();
    }

    void IRestart.Restart()
    {
        _restartComponents.RestartForEach();
    }
    
    void IAfterRestart.Restart()
    {
        _afterRestartComponents.RestartForEach();
    }
}