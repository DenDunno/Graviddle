using TMPro;
using UnityEngine;


public class CharacterRotationsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _characterRotationsText = null;


    public void UpdateRotationsUI(int rotations)
    {
        _characterRotationsText.text = rotations.ToString();
    }
}