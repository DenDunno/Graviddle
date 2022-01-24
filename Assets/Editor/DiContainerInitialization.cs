using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(EntryPoint))]
public class DiContainerInitialization : Editor
{
    public override void OnInspectorGUI() 
    {
        DrawDefaultInspector();
        
        if (GUILayout.Button("Fill DI container"))
        {
            MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>(true);
            var diContainer = FindObjectOfType<LightweightDiContainer>();
            
            List<MonoBehaviour> objectsWithDependencies = monoBehaviours.Where(CheckIfHasDependency).ToList();

            diContainer.SetObjectsWithDependencies(objectsWithDependencies);
            EditorUtility.SetDirty(diContainer);
            Logger.PrintWithGreen("Di container was initialized");
        }
    }
    

    private bool CheckIfHasDependency(MonoBehaviour monoBehaviour)
    {
        IEnumerable<FieldInfo> fieldsToInject = monoBehaviour.GetType().GetFieldsToInject();
        return fieldsToInject.Count() != 0;
    }
}