using TMPro;
using UnityEngine;


public class Reward : MonoBehaviour
{
    [SerializeField] private int _gold = 2;
    [SerializeField] private int _silver = 5;
    [SerializeField] private CharacterRotations _characterRotations = null;

    [SerializeField] private TMP_Text _goldUI = null;
    [SerializeField] private TMP_Text _silverUI = null;


    private void Start()
    {
        _goldUI.text = _gold.ToString();
        _silverUI.text = _silver.ToString();

        if (_characterRotations == null)
        {
            Debug.Log("<color=orange>No character rotations. Rotations set to 0. </color>" + gameObject);
        }
    }


    public int GetStars()
    {
        int rotations = _characterRotations?.Rotations ?? 0;

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
