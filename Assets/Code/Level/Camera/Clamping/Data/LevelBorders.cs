using System;
using UnityEngine;

[Serializable]
public class LevelBorders 
{
    [SerializeField] private Wall _left;
    [SerializeField] private Wall _right;
    [SerializeField] private Wall _top;
    [SerializeField] private Wall _bottom;
    private readonly float _deadDistance = 5f;
    
    public int Top => Mathf.RoundToInt(_top.transform.position.y);
    public int Bottom => Mathf.RoundToInt(_bottom.transform.position.y);
    public int Left => Mathf.RoundToInt(_left.transform.position.x);
    public int Right => Mathf.RoundToInt(_right.transform.position.x);

    public bool CheckIfPositionNotWithinTheLevel(Vector2 position)
    {
        Vector2 clampedPosition = new()
        {
            x = Mathf.Clamp(position.x, Left, Right),
            y = Mathf.Clamp(position.y, Bottom, Top)
        };

        return Vector2.Distance(position, clampedPosition) > _deadDistance;
    }
}
