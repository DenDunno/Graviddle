using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class LevelStarImpact : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactFX;
    [SerializeField] private AudioSource _impactSound;

    
    public async UniTask Activate(Vector2 impactPosition)
    {
        transform.position = impactPosition;
        _impactSound.Play();
        _impactFX.Play();

        await UniTask.Delay(TimeSpan.FromSeconds(_impactFX.main.duration));
    }
}