using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;


[Serializable]
public class LocalAssetLoader
{
    [SerializeField] private AssetReference _assetReference;
    private GameObject _gameObject;


    public async UniTask<T> Load<T>()
    {
        if (_gameObject != null)
        {
            throw new Exception("Object has not been released");
        }
        
        _gameObject = await Addressables.InstantiateAsync(_assetReference).Task;

        if (_gameObject.TryGetComponent(out T component) == false)
        {
            throw new NullReferenceException($"Failed to get {typeof(T)} from addressables");
        }

        return component;
    }
    
    
    public void Unload()
    {
        if (_gameObject == null)
        {
            throw new Exception("Object has already been released");
        }
        
        _gameObject.SetActive(false);
        Addressables.ReleaseInstance(_gameObject);
        _gameObject = null;
    }
}