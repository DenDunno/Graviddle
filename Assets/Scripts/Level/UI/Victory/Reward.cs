using UnityEngine;


public class Reward : MonoBehaviour
{
    [SerializeField] private int _gold = 2;
    [SerializeField] private int _silver = 5;
    [SerializeField] private CharacterRotations _characterRotations = null;


    public int GetStars()
    {
        int rotations = _characterRotations.Rotations;

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
