using UnityEngine;


public class LevelBorders : MonoBehaviour
{
    [SerializeField] private int _top = 0;
    [SerializeField] private int _down = 0;
    [SerializeField] private int _left = 0;
    [SerializeField] private int _right = 0;

    public int Top => _top;
    public int Down => _down;
    public int Left => _left;
    public int Right => _right;


    public bool CheckIfPositionNotWithinTheLevel(Vector2 position)
    {
        const float deadDistance = 5;

        var clampedPosition = new Vector2 
        {
            x = Mathf.Clamp(position.x, _left, _right),
            y = Mathf.Clamp(position.y, _down, _top)
        };

        return Vector2.Distance(position, clampedPosition) > deadDistance;
    }
}
