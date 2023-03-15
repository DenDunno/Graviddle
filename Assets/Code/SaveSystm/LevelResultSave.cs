using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResultSave : ISubscriber
{
    private readonly Reward _reward;
    private readonly WinState _winState;
    private readonly string _saves = "Saves";

    public LevelResultSave(Reward reward, WinState winState)
    {
        _reward = reward;
        _winState = winState;
    }

    void ISubscriber.Subscribe()
    {
        _winState.Entered += SaveLevelResult;
    }

    void ISubscriber.Unsubscribe()
    {
        _winState.Entered -= SaveLevelResult;
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
