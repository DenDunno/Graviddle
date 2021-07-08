using UnityEngine;


public class SwipeHandlerSwitcher : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private Character _character = null;


    private void OnEnable()
    {
        _character.CharacterDied += OnCharacterDied;
    }


    private void OnDisable()
    {
        _character.CharacterDied -= OnCharacterDied;
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