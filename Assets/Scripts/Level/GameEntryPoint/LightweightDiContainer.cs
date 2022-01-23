using System;
using System.Collections.Generic;
using UnityEngine;


public class LightweightDiContainer : MonoBehaviour
{
    private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
    private Dictionary<Type, List<ObjectWithDependency>> _dependencies;


    public void ResolveDependencies()
    {
        foreach (KeyValuePair<Type, List<ObjectWithDependency>> dependency in _dependencies)
        {
            foreach (ObjectWithDependency objectWithDependency in dependency.Value)
            {
                TypedReference typedReference = __makeref(objectWithDependency.Object);
                objectWithDependency.Field.SetValueDirect(typedReference, _instances[dependency.Key]);
            }
        }
    }
    

    public void RegisterTypeWithInstance(object component)
    {
        _instances[component.GetType()] = component;
    }


    public void SetDependencies(Dictionary<Type, List<ObjectWithDependency>> dependencies)
    {
        _dependencies = dependencies;
    }
}