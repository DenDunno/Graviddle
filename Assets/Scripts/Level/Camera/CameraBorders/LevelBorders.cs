using UnityEngine;


[System.Serializable]
public class LevelBorders
{
    [SerializeField] private int _topBorder = 0;
    [SerializeField] private int _downBorder = 0;
    [SerializeField] private int _leftBorder = 0;
    [SerializeField] private int _rightBorder = 0;

    public int TopBorder => _topBorder;
    public int DownBorder => _downBorder;
    public int LeftBorder => _leftBorder;
    public int RightBorder => _rightBorder;
}