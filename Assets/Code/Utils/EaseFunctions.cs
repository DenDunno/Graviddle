using UnityEngine;

public static class EaseFunctions
{
    public static float OutBack(float value, float x)
    {
        float c1 = value;
        float c2 = c1 + 1;

        return 1 + c2 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
    }
}