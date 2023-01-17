using UnityEngine;

public class LevelStarImpact : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactFX;
    [SerializeField] private AudioSource _impactSound;
    
    public void Activate(Vector2 impactPosition)
    {
        transform.position = impactPosition;
        _impactSound.Play();
        _impactFX.Play();
    }
}