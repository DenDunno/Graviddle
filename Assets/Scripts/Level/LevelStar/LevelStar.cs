using System;
using UnityEngine;


public class LevelStar : MonoBehaviour, IRestartableComponent
{
    public event Action StarCollected;
    
    
    private async void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            gameObject.SetActive(false);
            
            var levelStarImpact = await LocalAssetLoader.Load<LevelStarImpact>("LevelStarImpact");
            levelStarImpact.Activate(transform.position);
            
            
            StarCollected?.Invoke();
        }
    }


    void IRestartableComponent.Restart()
    {
        gameObject.SetActive(true);
    }
}
