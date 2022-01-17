using UnityEngine;


public class LaserRaycast : MonoBehaviour
{
    [SerializeField] private bool _updateRaycast;
    [SerializeField] private LaserSetup _laserSetup;
    [SerializeField] private LayerMask _layerMask;
    private const float _raycastDistance = 100f;


    private void Update()
    {
        if (TryRaycast(out Vector2 hitPoint))
        {
            _laserSetup.Setup(hitPoint);
            enabled = _updateRaycast;
        }
    }


    private bool TryRaycast(out Vector2 hitPoint)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, _raycastDistance, _layerMask);
        hitPoint = Vector2.zero;

        if (hit.collider != null)
        {
            hitPoint = hit.point;
        }

        else
        {
            Debug.LogError($"Laser with name \"{gameObject.name}\" cannot raycast");
        }

        return hit.collider != null;
    }
}