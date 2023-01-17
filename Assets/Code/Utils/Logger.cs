using UnityEngine;

public static class Logger
{
    public static void PrintWithGreen(string text)
    {
        Debug.Log("<color=#00FF00>" + text + "</color>");
    }
}