﻿using UnityEngine;


public class Reward : MonoBehaviour
{
    [SerializeField] private int _gold = 2;
    [SerializeField] private int _silver = 5;
    [SerializeField] private CharacterRotations _characterRotations;
    [SerializeField] private RewardListUI _rewardListUi;


    private void Start()
    {
        _rewardListUi.SetRewardListUI(_gold, _silver);

        if (_characterRotations == null)
        {
            Debug.Log("<color=orange>No character rotations. Rotations set to 0. </color>" + gameObject);
        }
    }


    public int GetStars()
    {
        int rotations = 2;

        if (rotations <= _gold)
        {
            return 3;
        }

        if (rotations > _gold && rotations <= _silver)
        {
            return 2;
        }

        return 1;
    }
}
