using System;
using UnityEngine;

public class LevelStar : MonoBehaviour, IRestart
{
    private StarPickupFeedback _starPickupFeedback;
    public event Action StarCollected;

    public void Init(StarPickupFeedback pickupFeedback)
    {
        _starPickupFeedback = pickupFeedback;
    }
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            gameObject.SetActive(false);
            
            _starPickupFeedback.Play(transform.position);
            
            StarCollected?.Invoke();
        }
    }

    void IRestart.Restart()
    {
        gameObject.SetActive(true);
    }
}
