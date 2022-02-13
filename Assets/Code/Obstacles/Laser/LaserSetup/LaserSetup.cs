using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserLine _laserLine;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster;
    [SerializeField] private LaserCollider _laserCollider;
    [SerializeField] private LaserHitObjectsPositions _laserHitObjectsPositions;
    [SerializeField] private bool _applyEffectsAdjustment = true;
    

    public void Setup(Vector2 hitPoint)
    {
        float laserDistance = Vector2.Distance(transform.position, hitPoint);

        if (_applyEffectsAdjustment)
        {
            _effectsAdjuster.ConfigureSourceEffects(laserDistance);
        }
        
        _laserCollider.SetupColliderDistance(laserDistance);
        _laserLine.SetupLineDistance(transform.position, hitPoint);
        _laserHitObjectsPositions.SetupPositions(hitPoint);
    }
}