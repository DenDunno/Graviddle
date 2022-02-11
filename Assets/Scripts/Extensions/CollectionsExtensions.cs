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
}