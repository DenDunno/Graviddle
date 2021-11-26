using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


public class LevelButtonsStars : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _levels = null;
    private Button[] _allButtons;
    private readonly string _saves = "Saves";


    private void Start()
    {
        if (PlayerPrefs.HasKey(_saves))
        {
            SetStarsForLevels();
        }
    }


    private void SetStarsForLevels()
    {
        var saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));
    }
}
