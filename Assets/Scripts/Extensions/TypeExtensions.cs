using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;


public static class TypeExtensions
{
    public static IEnumerable<FieldInfo> GetFieldsToInject(this Type type)
    {
        var fieldsToInject = new List<FieldInfo>();
        FillFieldsToInject(fieldsToInject, type);
        return fieldsToInject;
    }
    
    
    private static void FillFieldsToInject(List<FieldInfo> fieldsToInject, Type type)
    {
        if (type.BaseType != typeof(MonoBehaviour))
        {
            FillFieldsToInject(fieldsToInject, type.BaseType);
        }
        
        FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
        var fieldsToInjectInType = fields.Where(field => field.GetCustomAttribute<LightweightInjectAttribute>() != null);
        
        fieldsToInject.AddRange(fieldsToInjectInType);
    }
}