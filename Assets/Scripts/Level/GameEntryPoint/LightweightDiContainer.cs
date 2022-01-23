using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class LightweightDiContainer : MonoBehaviour
{
    private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
    [SerializeField] private List<Dependency> _dependencies;

    public void ResolveDependencies()
    {
        foreach (Dependency dependency in _dependencies)
        {
            dependency.Field.SetValue(null, _instances[dependency.Field.FieldType]);
        }
    }
    

    public void RegisterTypeWithInstance(object component)
    {
        _instances[component.GetType()] = component;
    }


    public void SetDependencies(List<Dependency> dependencies)
    {
        _dependencies = dependencies;
        EditorUtility.SetDirty(this);
        Debug.Log("DI container was filled");
    }
}