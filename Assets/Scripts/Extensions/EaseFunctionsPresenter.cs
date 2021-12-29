using UnityEngine;


public static class EaseFunctionsPresenter
{
    public static float EvaluateOutCubic(float normalizedX)
    {
        return 1 - Mathf.Pow(1 - normalizedX, 3);
    }
}