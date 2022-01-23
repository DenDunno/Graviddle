using System;
using System.Reflection;
using UnityEngine;


[Serializable]
public class Dependency
{
    [SerializeField] private MonoBehaviour _monoBehaviour;
    public FieldInfo Field;


    public Dependency(FieldInfo field, MonoBehaviour monoBehaviour)
    {
        Field = field;
        _monoBehaviour = monoBehaviour;
    }
}