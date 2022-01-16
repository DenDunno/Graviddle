using System;
using UnityEngine;


public class LevelStar : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private ParticleSystem _starImpact;
    public event Action StarCollected;
    
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            gameObject.SetActive(false);
            PlayFx();
            StarCollected?.Invoke();
        }
    }


    private void PlayFx()
    {
        _starImpact.transform.position = transform.position;
        _starImpact.Play();
    }
    
    
    void IRestartableComponent.Restart()
    {
        gameObject.SetActive(true);
    }
}
