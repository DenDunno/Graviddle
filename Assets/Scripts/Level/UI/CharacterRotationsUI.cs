using TMPro;
using UnityEngine;


public class CharacterRotationsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterRotationsText = null;


    public void UpdateValue(int rotations)
    {
        _characterRotationsText.text = rotations.ToString();
    }
}