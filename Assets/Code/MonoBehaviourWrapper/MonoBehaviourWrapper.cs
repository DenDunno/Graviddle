﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class MonoBehaviourWrapper : MonoBehaviour, IRestart, IAfterRestart
{
    private IEnumerable<IAfterRestart> _afterRestartComponents;
    private IEnumerable<IRestart> _restartComponents;
    private IEnumerable<ISubscriber> _subscribers;
    private IEnumerable<IFixedUpdate> _fixedUpdates;    
    private IEnumerable<IUpdate> _updates;
    private IEnumerable<ILateUpdate> _lateUpdates;

    protected void SetDependencies(IUnityCallback[] dependencies)
    {
        dependencies.OfType<IInitializable>().ForEach(initializable => initializable.Initialize());
        _afterRestartComponents = dependencies.OfType<IAfterRestart>();
        _restartComponents = dependencies.OfType<IRestart>();
        _subscribers = dependencies.OfType<ISubscriber>();
        _fixedUpdates = dependencies.OfType<IFixedUpdate>();
        _updates = dependencies.OfType<IUpdate>();
        _lateUpdates = dependencies.OfType<ILateUpdate>(); 
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