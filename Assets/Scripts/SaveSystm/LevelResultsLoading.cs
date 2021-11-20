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
            var saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(File.ReadAllText(savePath));

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
}
