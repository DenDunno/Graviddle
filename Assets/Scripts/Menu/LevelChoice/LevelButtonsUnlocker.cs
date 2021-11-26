using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;


public class LevelButtonsUnlocker : MonoBehaviour
{
    [SerializeField] private LevelButton[] _allButtons = null;
    private readonly string _saves = "Saves";
    private readonly int _menuScenesCount = 3;

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

        for (int i = 0; i < saves.Count; i++)
        {
            _allButtons[i].SetStars(saves[i + _menuScenesCount]);
            _allButtons[i].UnlockLevel();
        }
    }
}
