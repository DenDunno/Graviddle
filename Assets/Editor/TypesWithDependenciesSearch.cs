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
            MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>(true);
            var diContainer = FindObjectOfType<LightweightDiContainer>();
            
            var objectsWithDependencies = monoBehaviours.Where(CheckIfHasDependency).ToList();

            diContainer.SetObjectsWithDependencies(objectsWithDependencies);
        }
    }
    

    private bool CheckIfHasDependency(MonoBehaviour behaviour)
    {
        FieldInfo[] fields = behaviour.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        var dependencies = fields.Where(field => field.GetCustomAttribute<LightweightInjectAttribute>() != null);
        
        return dependencies.Count() != 0;
    }
}