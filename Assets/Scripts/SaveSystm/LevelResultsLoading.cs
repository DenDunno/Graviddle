using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


public class LevelResultsLoading : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _levels = null;
    private Button[] _allButtons;


    private void Start()
    {
        string savePath = Application.persistentDataPath + "Save.json";

        if (TryCreateDirectory(savePath) == false) // save exists
        {
            Dictionary<int,int> saves = LoadSaves(savePath);

        }
    }


    private bool TryCreateDirectory(string savePath)
    {
        bool noDirectory = false;

        if (File.Exists(savePath) == false)
        {
            File.Create(savePath);
            noDirectory = true;
        }

        return noDirectory;
    }


    private Dictionary<int, int> LoadSaves(string savePath)
    {
        string json = File.ReadAllText(savePath);

        return JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
    }
}
