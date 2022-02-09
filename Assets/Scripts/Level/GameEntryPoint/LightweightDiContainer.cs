using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class LightweightDiContainer : MonoBehaviour
{
    private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();


    public void ResolveDependencies(IEnumerable<MonoBehaviour> objectsWithDependencies)
    {
        foreach (MonoBehaviour monoBehaviour in objectsWithDependencies)
        {
            foreach (FieldInfo fieldToInject in monoBehaviour.GetType().GetFieldsToInject())
            {
                fieldToInject.SetValue(monoBehaviour, _instances[fieldToInject.FieldType]);
            }
        }
    }


    public void RegisterInstance(object instance)
    {
        _instances[instance.GetType()] = instance;
    }
}