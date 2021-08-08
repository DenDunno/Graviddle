using UnityEngine;


public class TouchCanvasSwitcher : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private CameraTouchControllingSwitcher _cameraTouchControllingSwitcher = null;


    private void OnEnable()
    {
        CharacterStates.DieState.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        CharacterStates.DieState.CharacterDied -= OnCharacterDied;
    }


    private void OnCharacterDied()
    {
        gameObject.SetActive(false);
    }


    void IAfterRestartComponent.Restart()
    {
        _cameraTouchControllingSwitcher.ToggleCameraTouchControlling(false);
        gameObject.SetActive(true);
    }
}