using System;
using UnityEngine;


public class Character : MonoBehaviour , IRestartableComponent
{
    public event Action CharacterDied = null;

    [SerializeField] private CharacterStates _characterStates = null;
    private bool _isAlive = true;


    private void Awake()
    {
        _characterStates.Init(this , Die);    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FinishPortal>(out var finishPortal) == true)
        {
            if (_isAlive == true)
            {
                finishPortal.FinishLevel();
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


    void IRestartableComponent.Restart()
    {
        _isAlive = true;
    }
}



