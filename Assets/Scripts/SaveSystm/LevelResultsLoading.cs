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
        string savePath = Application.persistentDataPath + "/Save.json";

        if (File.Exists(savePath) == false)
        {
            var fileStream = new FileStream(savePath, FileMode.Create);
            fileStream.Dispose();
        }

        else
        {
            PaintLevelButtons(savePath);
        }
    }

    private void PaintLevelButtons(string savePath)
    {
        var saves = JsonConvert.DeserializeObject<Dictionary<int, int>>(File.ReadAllText(savePath));
    }
}
