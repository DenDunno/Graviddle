using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum MoveTypeEnum { BUTTONS, TOUCH }
public enum GravityChangeTypeEnum { SWIPE, JOYSTICK }

public class Settings : MonoBehaviour
{
    public static MoveTypeEnum MoveType
    {
        get
        {
            if (PlayerPrefs.HasKey("MoveControlType"))
                return (MoveTypeEnum)PlayerPrefs.GetInt("MoveControlType");
            else
                return MoveTypeEnum.TOUCH;
        }

        private set { }
    }

    public static GravityChangeTypeEnum GravityChangeType
    {
        get
        {
            if (PlayerPrefs.HasKey("GravityChangeType"))
                return (GravityChangeTypeEnum)PlayerPrefs.GetInt("GravityChangeType");
            else
                return GravityChangeTypeEnum.SWIPE;
        }

        private set { }
    }


    public void OnChooseGravityChangeType(int _enum)
    {
        PlayerPrefs.SetInt("GravityChangeType", _enum);
    }

    public void OnChooseMoveType(int _enum)
    {
        PlayerPrefs.SetInt("MoveControlType", _enum);
    }
}

