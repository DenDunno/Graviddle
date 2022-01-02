using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserLine _laserLine = null;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster = null;
    [SerializeField] private LaserCollider _laserCollider = null;
    [SerializeField] private LaserLightBulb _laserLightBulb = null;
    [SerializeField] private ParticleSystem _hitEffect = null;


    public void Setup(Vector2 hitPoint)
    {
        float laserDistance = Vector2.Distance(transform.position, hitPoint);

        _laserCollider.SetupColliderDistance(laserDistance);
        _laserLine.SetupLineDistance(transform.position, hitPoint);
        _effectsAdjuster.ConfigureSourceEffects(laserDistance);
        _hitEffect.transform.SetPositionWithLocalOffset(hitPoint, new Vector2(0.05f, -0.05f));
        _laserLightBulb.transform.SetPositionWithLocalOffset(hitPoint, new Vector2(0.902f, -0.25f));
    }
}