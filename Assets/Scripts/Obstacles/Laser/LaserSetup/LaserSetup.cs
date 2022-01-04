using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserLine _laserLine = null;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster = null;
    [SerializeField] private LaserCollider _laserCollider = null;
    [SerializeField] private LaserHitObjectsPositions _laserHitObjectsPositions = null;


    public void Setup(Vector2 hitPoint)
    {
        float laserDistance = Vector2.Distance(transform.position, hitPoint);

        _laserCollider.SetupColliderDistance(laserDistance);
        _laserLine.SetupLineDistance(transform.position, hitPoint);
        _effectsAdjuster.ConfigureSourceEffects(laserDistance);
        _laserHitObjectsPositions.SetupPositions(hitPoint);
    }
}