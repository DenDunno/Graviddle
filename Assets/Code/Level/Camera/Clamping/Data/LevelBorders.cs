using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private int _top;
    [SerializeField] private int _down;
    [SerializeField] private int _left;
    [SerializeField] private int _right;

    public int Top => _top;
    public int Down => _down;
    public int Left => _left;
    public int Right => _right;

    public bool CheckIfPositionNotWithinTheLevel(Vector2 position)
    {
        const float deadDistance = 5;

        Vector2 clampedPosition = new()
        {
            x = Mathf.Clamp(position.x, _left, _right),
            y = Mathf.Clamp(position.y, _down, _top)
        };

        return Vector2.Distance(position, clampedPosition) > deadDistance;
    }
}
