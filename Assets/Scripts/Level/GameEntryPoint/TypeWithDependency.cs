using System;
using System.Reflection;


public class TypeWithDependency
{
    public readonly Type Type;
    public readonly FieldInfo Field;

    
    public TypeWithDependency(Type type, FieldInfo field)
    {
        Type = type;
        Field = field;
    }
}