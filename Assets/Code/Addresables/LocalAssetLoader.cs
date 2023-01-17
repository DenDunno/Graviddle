using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class LocalAssetLoader
{
    public static async UniTask<T> Load<T>(object key)
    {
        GameObject gameObject = await Addressables.InstantiateAsync(key).Task;

        if (gameObject.TryGetComponent(out T component) == false)
        {
            throw new NullReferenceException($"Failed to get {typeof(T)} from addressables");
        }

        return component;
    }
    
    public static void Unload(GameObject gameObjectToBeReleased)
    {
        gameObjectToBeReleased.SetActive(false);
        Addressables.ReleaseInstance(gameObjectToBeReleased);
    }
}