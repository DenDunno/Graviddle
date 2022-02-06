using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


public static class ParticlesHelper
{
    public static async void PlayAndDestroy(AssetReference reference, Transform transform)
    {
        var particles = await LocalAssetLoader.Load<ParticleSystem>(reference);
        particles.transform.SetPositionAndRotation(transform);
        particles.Play();
        await UniTask.Delay(TimeSpan.FromSeconds(particles.main.duration));
        LocalAssetLoader.Unload(particles.gameObject);
    }
}