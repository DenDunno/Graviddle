using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


public class LevelStar : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private AssetReference _starImpactReference;
    public event Action StarCollected;
    
    
    private async void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.GetComponent<Character>() != null)
        {
            gameObject.SetActive(false);
            
            var levelStarImpact = await LocalAssetLoader.Load<LevelStarImpact>(_starImpactReference);
            await levelStarImpact.Activate(transform.position);
            LocalAssetLoader.Unload(levelStarImpact.gameObject);
            
            StarCollected?.Invoke();
        }
    }


    void IRestartableComponent.Restart()
    {
        gameObject.SetActive(true);
    }
}
