using UnityEngine;

public class StarPickupFeedback : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactFX;
    [SerializeField] private AudioSource _impactSound;
    
    public void Play(Vector2 impactPosition)
    {
        transform.position = impactPosition;
        _impactSound.Play();
        _impactFX.Play();
    }
}