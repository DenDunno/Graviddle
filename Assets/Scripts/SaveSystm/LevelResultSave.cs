using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class LevelResultSave : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter;
    [SerializeField] private Reward _reward;
    private string _saves = "Saves";


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
        Dictionary<int, int> saves;

        if (PlayerPrefs.HasKey(_saves))
        {
            saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));
        }

        else
        {
            saves = new Dictionary<int, int>();
        }

        saves[SceneManager.GetActiveScene().buildIndex] = _reward.CollectedStars;

        PlayerPrefs.SetString(_saves, JsonConvert.SerializeObject(saves));
    }
}
