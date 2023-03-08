using System;
using UnityEngine;

[Serializable]
public class LevelStarsMediator
{
    [SerializeField] private LevelStar[] _levelStars;
    [SerializeField] private StarPickupFeedback _starPickupFeedback;
    [SerializeField] private Reward _reward;
    
    public void Resolve(CharacterGravityState characterCharacterGravityState)
    {
        foreach (LevelStar levelStar in _levelStars)
        {
            levelStar.Init(_starPickupFeedback, characterCharacterGravityState);
        }
        
        _reward.Init(_levelStars);
    }
}