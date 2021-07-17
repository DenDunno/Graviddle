using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour , IAfterRestartComponent
{
    [SerializeField] private CharacterStates _characterStates = null;
    [SerializeField] private CharacterTransparency _characterTransparency = null;

    private bool _isAlive = true;


    private void Awake()
    {
        _characterStates.Init(this);
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
        if (collision.TryGetComponent<FinishPortal>(out var finishPortal) == true)
        {
            if (_isAlive == true)
            {
                finishPortal.FinishLevel();
                float waitTime = 1f;

                yield return new WaitForSeconds(waitTime);

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



