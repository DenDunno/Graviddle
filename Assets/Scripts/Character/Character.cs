using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private CharacterTransparency _characterTransparency = null;
    [SerializeField] private CharacterVictory _characterVictory = null;
    
    private bool _isAlive = true;


    private void Awake()
    {
        CharacterStates.Init(this);
        CharacterStates.DieState.CharacterDied += OnCharacterDied;
        
        _characterTransparency.BecomeTransparentNow();
        _characterTransparency.BecomeOpaque(this);
    }


    private void OnDestroy()
    {
        CharacterStates.DieState.CharacterDied -= OnCharacterDied;
    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out FinishPortal finishPortal))
        {
            if (_isAlive)
            {
                _characterVictory.FinishLevel(this, finishPortal);

                float timeBeforeDisappearance = 1f;
                yield return new WaitForSeconds(timeBeforeDisappearance);

                _characterTransparency.BecomeTransparent(this);
            }
        }
    }


    private void OnCharacterDied()
    {
        _isAlive = false;
    }


    void IAfterRestartComponent.Restart()
    {
        _isAlive = true;
    }
}