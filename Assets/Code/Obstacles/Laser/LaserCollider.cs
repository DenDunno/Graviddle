using UnityEngine;


public class LaserCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private LaserSwitcher _laserSwitcher;


    public void SetupColliderDistance(float laserDistance)
    {
        float colliderOffset = 0.5f * laserDistance;
        
        _boxCollider.size = new Vector2(_boxCollider.size.x, laserDistance);
        _boxCollider.offset = new Vector2(_boxCollider.offset.x, colliderOffset);
    }


    private void OnEnable()
    {
        _laserSwitcher.LaserToggled += ToggleCollider;
    }


    private void OnDisable()
    {
        _laserSwitcher.LaserToggled -= ToggleCollider;
    }


    private void ToggleCollider(bool activate)
    {
        _boxCollider.enabled = activate;
    }
}