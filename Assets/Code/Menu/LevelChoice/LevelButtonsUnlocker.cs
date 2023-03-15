using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LevelButtonsUnlocker : MonoBehaviour
{
    private LevelButton[] _allButtons;
    private readonly string _saves = "Saves";
    private readonly int _menuScenesCount = 1;

    private void Start()
    {
        _allButtons = GetComponentsInChildren<LevelButton>();
        
        if (PlayerPrefs.HasKey(_saves))
        {
            UnlockLevels();
        }

        else
        {
            _allButtons[0].UnlockLevel();
        }
    }

    private void UnlockLevels()
    {
        Dictionary<int, int> saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));

        for (int i = 0; i < saves.Count; i++)
        {
            _allButtons[i].SetStars(saves[i + _menuScenesCount]);
            _allButtons[i].UnlockLevel();
        }

        int levelToBeUnlocked = saves.Count;

        if (levelToBeUnlocked < _allButtons.Length)
        {
            _allButtons[levelToBeUnlocked].UnlockLevel();
        }
    }
}