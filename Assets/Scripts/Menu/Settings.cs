using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public enum MoveTypeEnum { BUTTONS, TOUCH }
public enum GravityChangeTypeEnum { SWIPE, JOYSTICK }

public class Settings : MonoBehaviour
{

    private MoveTypeEnum _moveType = MoveTypeEnum.TOUCH;
    private GravityChangeTypeEnum _gravityChangeType = GravityChangeTypeEnum.JOYSTICK;

    private GameObject _touchCanvasPrefab;
    private GameObject _joystick;
    private string _touchCanvasPath = "Assets/Resources/Prefabs/Level/TouchCanvas.prefab";

    private void Start()
    {
        _joystick = Resources.Load<GameObject>("Prefabs/Level/FixedJoystick");
    }

    public void OnChooseGravityChangeType(int _enum)
    {
        _gravityChangeType = (GravityChangeTypeEnum)_enum;
        SetCharacterControl(_moveType, _gravityChangeType);
    }

    public void OnChooseMoveType(int _enum)
    {
        _moveType = (MoveTypeEnum)_enum;
        SetCharacterControl(_moveType, _gravityChangeType);
    }

    private void SetCharacterControl(MoveTypeEnum moveType , GravityChangeTypeEnum gravityChangeType)
    {
        _touchCanvasPrefab = PrefabUtility.LoadPrefabContents(_touchCanvasPath);

        DestroyImmediate(_touchCanvasPrefab.GetComponent<MoveСontrolType>());
        DestroyImmediate(_touchCanvasPrefab.GetComponent<GravityChangeType>());

        switch (moveType)
        {
            case MoveTypeEnum.TOUCH:
                _touchCanvasPrefab.AddComponent<Touch>();
                break;

            case MoveTypeEnum.BUTTONS:
                _touchCanvasPrefab.AddComponent<Buttons>();
                break;
        }

        switch (gravityChangeType)
        {
            case GravityChangeTypeEnum.SWIPE:
                _touchCanvasPrefab.AddComponent<Swipe>();
                break;

            case GravityChangeTypeEnum.JOYSTICK:
                _touchCanvasPrefab.AddComponent<Joystickk>();
                break;
        }

        PrefabUtility.SaveAsPrefabAsset(_touchCanvasPrefab, _touchCanvasPath);
        PrefabUtility.UnloadPrefabContents(_touchCanvasPrefab);
    }
}

