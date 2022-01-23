using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(MonobehaviorsWithDependenciesSearch))]
public class TypesWithDependenciesSearch : Editor
{
    public override void OnInspectorGUI() 
    {
        if (GUILayout.Button("Fill DI container"))
        {
            var dependencies = new List<Dependency>();
            MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>(true);
            var diContainer = FindObjectOfType<LightweightDiContainer>();

            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
            {
                IEnumerable<FieldInfo> fieldsWithDependencies = GetFieldsWithDependencies(monoBehaviour.GetType());

                foreach (FieldInfo fieldInfo in fieldsWithDependencies)
                {
                    dependencies.Add(new Dependency(fieldInfo, monoBehaviour));
                }
            }
            
            diContainer.SetDependencies(dependencies);
        }
    }
    

    private IEnumerable<FieldInfo> GetFieldsWithDependencies(Type type)
    {
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        return fields.Where(field => field.GetCustomAttribute<LightweightInjectAttribute>() != null);
    }
}