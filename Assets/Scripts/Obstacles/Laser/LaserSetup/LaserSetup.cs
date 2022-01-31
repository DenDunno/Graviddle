using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserLine _laserLine;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster;
    [SerializeField] private LaserCollider _laserCollider;
    [SerializeField] private LaserHitObjectsPositions _laserHitObjectsPositions;


    public void Setup(Vector2 hitPoint)
    {
        float laserDistance = Vector2.Distance(transform.position, hitPoint);
        
        _laserCollider.SetupColliderDistance(laserDistance);
        _laserLine.SetupLineDistance(transform.position, hitPoint);
        _effectsAdjuster.ConfigureSourceEffects(laserDistance);
        _laserHitObjectsPositions.SetupPositions(hitPoint);
    }
}