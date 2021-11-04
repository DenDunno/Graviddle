using System.Threading.Tasks;
using UnityEngine;
using Zenject;


[RequireComponent(typeof(CharacterTransparency))]
public class Character : MonoBehaviour
{
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private CharacterTransparency _characterTransparency;


    private void Start()
    {
        _characterTransparency = GetComponent<CharacterTransparency>();
    }


    private void OnEnable()
    {
        _characterStatesPresenter.WinState.CharacterWon += OnCharacterWon;
    }


    private void OnDisable()
    {
        _characterStatesPresenter.WinState.CharacterWon -= OnCharacterWon;
    }


    private async void OnCharacterWon()
    {
        const int timeBeforeDisappearance = 1000;

        await Task.Delay(timeBeforeDisappearance);

        _characterTransparency.BecomeTransparent();
    }
}