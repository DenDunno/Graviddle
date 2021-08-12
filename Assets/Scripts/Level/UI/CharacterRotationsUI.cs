using TMPro;
using UnityEngine;


public class CharacterRotationsUI : MonoBehaviour , IRestartableComponent
{
    [SerializeField] private TextMeshProUGUI _characterRotationsText = null;


    public void UpdateValue(int rotations)
    {
        _characterRotationsText.text = rotations.ToString();
    }


    void IRestartableComponent.Restart()
    {
    }
}