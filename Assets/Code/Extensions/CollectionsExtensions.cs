﻿using System;
using System.Collections.Generic;


public static class CollectionsExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }
    
    
    public static bool IsEmpty<T>(this Stack<T> stack)
    {
        return stack.Count == 0;
    }
    
    
    public static bool IsEmpty<T>(this Queue<T> queue)
    {
        return queue.Count == 0;
    }


    public static void SubscribeForEach(this IEnumerable<ISubscriber> subscribers)
    {
        subscribers.ForEach(subscriber => subscriber.Subscribe());
    }
    
    
    public static void UnsubscribeForEach(this IEnumerable<ISubscriber> subscribers)
    {
        subscribers.ForEach(subscriber => subscriber.Unsubscribe());
    }
    
    
    public static void RestartForEach(this IEnumerable<IRestart> restartComponents)
    {
        restartComponents.ForEach(restartComponent => restartComponent.Restart());
    }
    
    
    public static void RestartForEach(this IEnumerable<IAfterRestart> afterRestartComponents)
    {
        afterRestartComponents.ForEach(afterRestartComponent => afterRestartComponent.Restart());
    }
    
    
    public static void UpdateForEach(this IEnumerable<IUpdate> updatables)
    {
        updatables.ForEach(updatable => updatable.Update());
    }
    
    
    public static void FixedUpdateForEach(this IEnumerable<IFixedUpdate> fixedUpdates)
    {
        fixedUpdates.ForEach(updatable => updatable.FixedUpdate());
    }
}