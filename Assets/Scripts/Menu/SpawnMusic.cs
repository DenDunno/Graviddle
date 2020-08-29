using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMusic : MonoBehaviour
{
    private Object music = null;

    private void Start()
    { 
        if (!GameObject.FindGameObjectWithTag("Menu_music"))
        {
            music = Resources.Load("Prefabs/Menu/Music");
            DontDestroyOnLoad(Instantiate(music));
            /*
              Так как на music висит DontDestroy, то условие выполнится один раз (При запуске главного меню)
              Т.е. одна непрерывная музыка на все "менюшные" сцены
            */
        }
    }

}
