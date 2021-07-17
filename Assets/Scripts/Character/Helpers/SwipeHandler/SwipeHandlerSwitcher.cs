using UnityEngine;


public class SwipeHandlerSwitcher : MonoBehaviour , IAfterRestartComponent
{
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
        gameObject.SetActive(true);
    }
}