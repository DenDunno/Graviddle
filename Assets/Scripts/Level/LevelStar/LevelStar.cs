using System;
using UnityEngine;


public class LevelStar : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private LevelStarImpact _levelStarImpact;
    public event Action StarCollected;
    
    
    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            gameObject.SetActive(false);
            
            _levelStarImpact.Activate(transform.position);
            
            StarCollected?.Invoke();
        }
    }


    void IRestartableComponent.Restart()
    {
        gameObject.SetActive(true);
    }
}
