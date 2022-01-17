using System.Collections.Generic;


public static class DictionaryExtensions
{
    public static Dictionary<T, List<TY>> Merge<T,TY>(this IReadOnlyDictionary<T, List<TY>> first , IReadOnlyDictionary<T, List<TY>> second)
    {
        var merge = new Dictionary<T, List<TY>>();

        FillDictionary(merge, first);
        FillDictionary(merge, second);

        return merge;
    }


    private static void FillDictionary<T, TY>(Dictionary<T, List<TY>> container, IReadOnlyDictionary<T, List<TY>> source)
    {
        foreach (KeyValuePair<T, List<TY>> keyValuePair in source)
        {
            foreach (TY y in keyValuePair.Value)
            {
                if (container.ContainsKey(keyValuePair.Key) == false)
                {
                    container[keyValuePair.Key] = new List<TY>();
                }

                container[keyValuePair.Key].Add(y);
            }
        }
    }
}