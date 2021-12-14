using System.Threading.Tasks;
using UnityEngine;
using Zenject;


public class CharacterTransparency : MonoBehaviour , IRestartableComponent , IAfterRestartComponent
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [Inject] private readonly CharacterStatesPresenter _characterStatesPresenter = null;
    private SpriteTransparencyPresenter _spriteTransparencyPresenter;


    private void Start()
    {
        _spriteTransparencyPresenter = new SpriteTransparencyPresenter(_spriteRenderer);

        _spriteTransparencyPresenter.BecomeTransparentNow();
        _spriteTransparencyPresenter.BecomeOpaque();
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

        _spriteTransparencyPresenter.BecomeTransparent();
    }


    void IRestartableComponent.Restart()
    {
        _spriteTransparencyPresenter.StopAnimation();
        _spriteTransparencyPresenter.BecomeTransparentNow();
    }


    void IAfterRestartComponent.Restart()
    {
        _spriteTransparencyPresenter.BecomeOpaque();
    }
}