using UnityEngine;


public class LaserSetup : MonoBehaviour
{
    [SerializeField] private LaserDistance _laserDistance = null;
    [SerializeField] private LaserSourceEffectsAdjuster _effectsAdjuster = null;


    public void Setup(Vector2 hitPoint)
    {
        _laserDistance.Setup(transform.position, hitPoint);
        _effectsAdjuster.ConfigureSourceEffects(Vector2.Distance(transform.position, hitPoint));
    }
}