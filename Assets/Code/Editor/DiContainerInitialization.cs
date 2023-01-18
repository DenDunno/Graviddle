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
            EditorInterfacesContainer container = FindObjectOfType<EditorInterfacesContainer>();
            container.FillContainers();
            EditorUtility.SetDirty(container);
            
            Logger.PrintWithGreen("Scene was resolved");
        }
    }
}