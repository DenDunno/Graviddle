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
        
        if (GUILayout.Button("Resolve scene"))
        {
            var container = FindObjectOfType<EditorMonoBehavioursContainer>();
            container.FillContainers();
            
            Logger.PrintWithGreen("Scene was resolved");
        }
    }
}