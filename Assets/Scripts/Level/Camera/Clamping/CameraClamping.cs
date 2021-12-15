using UnityEngine;


[RequireComponent(typeof(CameraBordersWithOrientation))]
public class CameraClamping : MonoBehaviour
{
    private CameraBordersWithOrientation _borders;


    private void Start()
    {
        _borders = GetComponent<CameraBordersWithOrientation>();
    }


    public void ClampCamera(ref Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, _borders.Left, _borders.Right);
        position.y = Mathf.Clamp(position.y, _borders.Down, _borders.Top);
    }
}