using UnityEngine;


public class ButtonMovement : MonoBehaviour
{
    private const float _topExtremePoint = 0.35f;
    private const float _downExtremePoint = 0f;
    

    public void FixedUpdate()
    {
        Vector2 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _downExtremePoint, _topExtremePoint);
        
        transform.localPosition = clampedPosition;
    }
}