using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class CharacterTransparency : MonoBehaviour , IRestartableComponent , IAfterRestartComponent
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private TransparencyInterface _transparencyInterface;


    private void Start()
    {
        _transparencyInterface = new TransparencyInterface(_spriteRenderer);

        _transparencyInterface.BecomeTransparentNow();
        _transparencyInterface.BecomeOpaque();
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

        _transparencyInterface.BecomeTransparent();
    }


    void IRestartableComponent.Restart()
    {
        _transparencyInterface.StopAnimation();
        _transparencyInterface.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _transparencyInterface.BecomeOpaque();
    }
}