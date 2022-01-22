using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserLine _laserLine;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster;
    [SerializeField] private LaserCollider _laserCollider;
    [SerializeField] private LaserHitObjectsPositions _laserHitObjectsPositions;
    private const float _hitPointLineOffset = 0.5f;

    public void Setup(Vector2 hitPoint)
    {
        float laserDistance = Vector2.Distance(transform.position, hitPoint);

        _laserCollider.SetupColliderDistance(laserDistance);
        _laserLine.SetupLineDistance(transform.position, hitPoint + (Vector2)transform.up * _hitPointLineOffset);
        _effectsAdjuster.ConfigureSourceEffects(laserDistance);
        _laserHitObjectsPositions.SetupPositions(hitPoint);
    }
}