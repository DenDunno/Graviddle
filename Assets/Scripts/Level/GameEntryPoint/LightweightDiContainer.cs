using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public class LightweightDiContainer : MonoBehaviour
{
    private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();
    [SerializeField] private List<MonoBehaviour> _objectsWithDependency;

    
    public void ResolveDependencies()
    {
        foreach (MonoBehaviour monoBehaviour in _objectsWithDependency)
        {
            foreach (FieldInfo fieldToInject in GetFieldsToInject(monoBehaviour))
            {
                fieldToInject.SetValue(monoBehaviour, _instances[fieldToInject.FieldType]);
            }
        }
    }


    private IEnumerable<FieldInfo> GetFieldsToInject(MonoBehaviour monoBehaviour)
    {
        FieldInfo[] fields = monoBehaviour.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        return fields.Where(field => field.GetCustomAttribute<LightweightInjectAttribute>() != null);
    }


    public void RegisterTypeWithInstance(object component)
    {
        _instances[component.GetType()] = component;
    }


    public void SetObjectsWithDependencies(List<MonoBehaviour> objectsWithDependency)
    {
        _objectsWithDependency = objectsWithDependency;
        EditorUtility.SetDirty(this);
        Debug.Log("DI container was filled");
    }
}