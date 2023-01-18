using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResultSave : MonoBehaviour
{
    [SerializeField] private Reward _reward;
    private const string _saves = "Saves";
    private WinState _characterWinState;

    public void Init(WinState winState)
    {
        _characterWinState = winState;
    }

    public void OnEnable()
    {
        _characterWinState.CharacterWon += SaveLevelResult;
    }

    public void OnDisable()
    {
        _characterWinState.CharacterWon -= SaveLevelResult;
    }

    private void SaveLevelResult()
    {
        Dictionary<int, int> saves = new();

        if (PlayerPrefs.HasKey(_saves))
        {
            saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));
        }

        saves[SceneManager.GetActiveScene().buildIndex] = _reward.CollectedStars;

        PlayerPrefs.SetString(_saves, JsonConvert.SerializeObject(saves));
    }
}
