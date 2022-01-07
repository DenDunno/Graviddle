using System.Collections.Generic;


public static class DictionaryExtensions
{
    public static Dictionary<T, List<Y>> Merge<T,Y>(this IReadOnlyDictionary<T, List<Y>> first , IReadOnlyDictionary<T, List<Y>> second)
    {
        var merge = new Dictionary<T, List<Y>>();

        FillDictionary(merge, first);
        FillDictionary(merge, second);

        return merge;
    }


    private static void FillDictionary<T, Y>(Dictionary<T, List<Y>> container, IReadOnlyDictionary<T, List<Y>> source)
    {
        foreach (KeyValuePair<T, List<Y>> keyValuePair in source)
        {
            foreach (Y y in keyValuePair.Value)
            {
                if (container.ContainsKey(keyValuePair.Key) == false)
                {
                    container[keyValuePair.Key] = new List<Y>();
                }

                container[keyValuePair.Key].Add(y);
            }
        }
    }
}