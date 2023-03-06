using System;
using System.Collections.Generic;
using System.Linq;

public static class CollectionsExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }
    
    public static bool IsEmpty<T>(this IEnumerable<T> collection)
    {
        return !collection.Any();
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
        updatables.ForEach(update => update.Update());
    }
    
    public static void LateUpdateForEach(this IEnumerable<ILateUpdate> updatables)
    {
        updatables.ForEach(update => update.LateUpdate());
    }

    public static void FixedUpdateForEach(this IEnumerable<IFixedUpdate> fixedUpdates)
    {
        fixedUpdates.ForEach(update => update.FixedUpdate());
    }
}