using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour, IRestart
{
    private IReadOnlyCollection<LevelStar> _levelStars;
    private readonly int _maxStars = 3;

    public int CollectedStars { get; private set; }
    public bool IsMaxStars => CollectedStars == _maxStars;

    public void Init(IReadOnlyCollection<LevelStar> levelStars)
    {
        _levelStars = levelStars;
    }
    
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
    
    void IRestart.Restart()
    {
        CollectedStars = 0;
    }
}
