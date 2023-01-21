﻿using UnityEngine;

public class Reward : MonoBehaviour, IRestart
{
    [SerializeField] private LevelStar[] _levelStars;
    private const int _maxStars = 3;

    public int CollectedStars { get; private set; }
    public bool IsMaxStars => CollectedStars == _maxStars;
    
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