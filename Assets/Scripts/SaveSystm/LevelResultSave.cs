using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;


public class LevelResultSave : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    [SerializeField] private Reward _reward = null;


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
        string savePath = Application.persistentDataPath + "/Save.json";
        string json = File.ReadAllText(savePath);

        var save = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);

        save ??= new Dictionary<int, int>();

        save[SceneManager.GetActiveScene().buildIndex] = _reward.GetStars();

        json = JsonConvert.SerializeObject(save);

        File.WriteAllText(savePath , json);
    }
}
