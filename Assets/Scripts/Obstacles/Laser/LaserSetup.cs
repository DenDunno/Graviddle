using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LineRenderer _laser = null;
    [SerializeField] private ParticleSystem _hitEffect = null;
    [SerializeField] private Collider2D _collider2d = null;
    [SerializeField] private LayerMask _layerMask = default;
    private readonly Vector3 _hitEffectOffset = new Vector3(0.05f, -0.05f);
    private readonly float _raycastDistance = 100f;


    private void Update()
    {
        TryRaycast();
    }


    private void TryRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(_laser.transform.position, _laser.transform.up, _raycastDistance, _layerMask);

        if (hit.collider != null)
        {
            SetLine(hit.point);
            SetHitEffect(hit.point);
            SetCollider(hit.point);
        }

        else
        {
            Debug.LogError($"Laser with name \"{gameObject.name}\" cannot raycast");
        }
    }


    private void SetLine(Vector3 destinationPosition)
    {
        _laser.SetPosition(0, _laser.transform.position);
        _laser.SetPosition(1, destinationPosition);
    }


    private void SetHitEffect(Vector2 destinationPosition)
    {
        _hitEffect.transform.position = destinationPosition;
        _hitEffect.transform.localPosition += _hitEffectOffset;
    }


    private void SetCollider(Vector3 destinationPosition)
    {
        
    }
}