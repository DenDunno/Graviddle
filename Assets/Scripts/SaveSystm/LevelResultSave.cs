using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelResultSave : MonoBehaviour
{
    [LightweightInject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [SerializeField] private Reward _reward;
    private const string _saves = "Saves";


    public void OnEnable()
    {
        _characterStatesPresenter.WinState.CharacterWon += SaveLevelResult;
    }


    public void OnDisable()
    {
        _characterStatesPresenter.WinState.CharacterWon -= SaveLevelResult;
    }


    private void SaveLevelResult()
    {
        var saves = new Dictionary<int, int>();

        if (PlayerPrefs.HasKey(_saves))
        {
            saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));
        }

        saves[SceneManager.GetActiveScene().buildIndex] = _reward.CollectedStars;

        PlayerPrefs.SetString(_saves, JsonConvert.SerializeObject(saves));
    }
}
