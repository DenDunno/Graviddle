using UnityEngine;


public class ButtonClamping : MonoBehaviour
{
    private const float _topExtremePoint = 0.36f;
    private const float _downExtremePoint = 0f;
    

    public void FixedUpdate()
    {
        Vector2 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _downExtremePoint, _topExtremePoint);
        
        transform.localPosition = clampedPosition;
    }
}
