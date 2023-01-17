using UnityEngine;

public class AnimationPath
{
    public readonly Vector2 StartPosition;
    public readonly Vector2 EndPosition;

    public AnimationPath(Vector2 startPosition, Vector2 endPosition)
    {
        StartPosition = startPosition;
        EndPosition = endPosition;
    }
}
