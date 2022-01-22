using UnityEngine;


public class Reward : MonoBehaviour, IRestartableComponent
{
    [SerializeField] private LevelStar[] _levelStars;
    public const int MaxStars = 3;
    public int CollectedStars { get; private set; }
    
    
    private void OnEnable()
    {
        _levelStars.ForEach(levelStar => levelStar.StarCollected += OnStarCollected);
    }


    private void OnDisable()
    {
        _levelStars.ForEach(levelStar => levelStar.StarCollected -= OnStarCollected);
    }


    private void OnStarCollected()
    {
        ++CollectedStars;
    }

    
    void IRestartableComponent.Restart()
    {
        CollectedStars = 0;
    }
}
