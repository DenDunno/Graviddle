using Sirenix.OdinInspector;
using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] [ChildGameObjectsOnly] private Transform _left;
    [SerializeField] [ChildGameObjectsOnly] private Transform _right;
    [SerializeField] [ChildGameObjectsOnly] private Transform _top;
    [SerializeField] [ChildGameObjectsOnly] private Transform _bottom;

    public int Top => Mathf.RoundToInt(_top.position.y);
    public int Bottom => Mathf.RoundToInt(_bottom.position.y);
    public int Left => Mathf.RoundToInt(_left.position.x);
    public int Right => Mathf.RoundToInt(_right.position.x);

    public bool CheckIfPositionNotWithinTheLevel(Vector2 position)
    {
        const float deadDistance = 5;

        Vector2 clampedPosition = new()
        {
            x = Mathf.Clamp(position.x, Left, Right),
            y = Mathf.Clamp(position.y, Bottom, Top)
        };

        return Vector2.Distance(position, clampedPosition) > deadDistance;
    }
}
