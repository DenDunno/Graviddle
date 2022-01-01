using UnityEngine;
using System;


[Serializable]
public class LevelBorders
{
    [SerializeField] private int _top = 0;
    [SerializeField] private int _down = 0;
    [SerializeField] private int _left = 0;
    [SerializeField] private int _right = 0;

    public int Top => _top;
    public int Down => _down;
    public int Left => _left;
    public int Right => _right;
}