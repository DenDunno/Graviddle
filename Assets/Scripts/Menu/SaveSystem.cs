using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    [SerializeField]
    private Button[] _levelButtons = null;

    private Dictionary<string, Color32> _paintButton = new Dictionary<string, Color32>
    {
        {"Gold"   , new Color32(255, 223, 0 , 255) },
        {"Silver" , new Color32(192, 192, 192, 255)},
        {"Bronze" , new Color32(205, 127, 50, 255)   } 
    };

    
    private void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "Save.json");
        string json = "";

        if (File.Exists(path))
            json = File.ReadAllText(path);

        else
            File.WriteAllText(path, json);


        if (json.Length != 0) 
            OpenLevels(json);

        _levelButtons[0].interactable = true; 
    }


    private void OpenLevels(string json)
    {
        var levels = new Dictionary<int, string>();
        levels = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);


        for (int i = 0; i < _levelButtons.Length; ++i)
        {
            if (i <= levels.Count) // открой все пройденные уровни и следующий
                _levelButtons[i].interactable = true;

            if (i < levels.Count) // // раскрасить кнопку пройденных уровней в золотой, серебрянный или бронзовый цвет
                _levelButtons[i].GetComponent<Image>().color = _paintButton[levels[i]];
        }
    }

    public static void MakeSave(int indexOfLevel, string result)
    {
        string json = "";
        string path = Path.Combine(Application.persistentDataPath, "Save.json");
        Dictionary<int, string> levels = new Dictionary<int, string>();

        if (File.Exists(path))
            json = File.ReadAllText(path);

        levels = JsonConvert.DeserializeObject<Dictionary<int, string>>(json);
        if (levels == null)
            levels = new Dictionary<int, string>();

        levels[indexOfLevel] = result;

        json = JsonConvert.SerializeObject(levels);

        File.WriteAllText(Path.Combine(Application.persistentDataPath, "Save.json"), json);
    }
}
