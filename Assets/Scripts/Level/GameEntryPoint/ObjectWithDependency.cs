using System.Reflection;


public class ObjectWithDependency
{
    public object Object;
    public readonly FieldInfo Field;

    
    public ObjectWithDependency(object @object, FieldInfo field)
    {
        Object = @object;
        Field = field;
    }
}