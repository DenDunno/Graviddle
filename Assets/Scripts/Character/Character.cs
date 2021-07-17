using System;
using System.Collections;
using UnityEngine;


public class Character : MonoBehaviour , IAfterRestartComponent
{
    public event Action CharacterDied = null;

    [SerializeField] private CharacterStates _characterStates = null;
    [SerializeField] private CharacterTransparency _characterTransparency = null;

    private bool _isAlive = true;


    private void Awake()
    {
        _characterStates.Init(this , Die);

        _characterTransparency.BecomeTransparentNow();
        _characterTransparency.BecomeOpaque(this);
    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FinishPortal>(out var finishPortal) == true)
        {
            if (_isAlive == true)
            {
                finishPortal.FinishLevel();
                yield return new WaitForSeconds(1f);

                _characterTransparency.BecomeTransparent(this);
            }
        }
    }


    private void Die()
    {
        if (_isAlive == true)
        {
            _isAlive = false;
            CharacterDied?.Invoke();
        }
    }


    void IAfterRestartComponent.Restart()
    {
        _isAlive = true;
    }
}



