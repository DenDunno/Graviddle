using UnityEngine;


[RequireComponent(typeof(CameraBordersWithOrientation))]
public class CameraClamping : MonoBehaviour
{
    private CameraBordersWithOrientation _borders;
    private const float _cameraZPosition = -10;

    private void Start()
    {
        _borders = GetComponent<CameraBordersWithOrientation>();
    }


    public Vector3 Clamp(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, _borders.Left, _borders.Right);
        position.y = Mathf.Clamp(position.y, _borders.Down, _borders.Top);
        position.z = _cameraZPosition;
        
        TryCentreCameraAxis(_borders.Right, _borders.Left, ref position.x);
        TryCentreCameraAxis(_borders.Top, _borders.Down, ref position.y);

        return position;
    }


    private void TryCentreCameraAxis(float upBorder, float downBorder, ref float cameraAxisPosition)
    {
        if (upBorder - downBorder <= 0)
        {
            cameraAxisPosition = (upBorder + downBorder) / 2f;
        }
    }
}