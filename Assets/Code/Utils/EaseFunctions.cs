using UnityEngine;

public static class EaseFunctions
{
    public static float OutBack(float value, float x = 1.70158f)
    {
        float c1 = value;
        float c2 = c1 + 1;

        return 1 + c2 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }
    
    public static float InCirc(float x) 
    {
        return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
    }
    
    public static float InCubic(float x)
    {
        return x * x * x;
    }
    
    public static float InQuint(float x)
    {
        return x * x * x * x;
    }
    
    public static float OutQuart(float x)
    {
        return 1 - Mathf.Pow(1 - x, 4);
    }
}