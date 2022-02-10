using System;
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


    public static void TryAddToList<TY, T>(this ICollection<T> collection, T obj)
    {
        if (obj is TY)
        {
            collection.Add(obj);
        }
    }
    
    
    public static void TryCastAndAdd<T>(this ICollection<T> collection, object obj)
    {
        if (obj is T custedObj)
        {
            collection.Add(custedObj);
        }
    }
}