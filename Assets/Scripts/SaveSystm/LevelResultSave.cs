using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class LevelResultSave : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    [SerializeField] private Reward _reward = null;
    private string _saves = "Save";


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
        Dictionary<int , int> saves;

        if (PlayerPrefs.HasKey(_saves))
        {
            saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(PlayerPrefs.GetString(_saves));

            saves[SceneManager.GetActiveScene().buildIndex] = _reward.GetStars();
        }

        else
        {
            saves = new Dictionary<int, int>();
        }

        PlayerPrefs.SetString(_saves, JsonConvert.SerializeObject(saves));
    }
}
