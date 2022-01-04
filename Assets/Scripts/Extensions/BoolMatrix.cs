using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class BoolArray 
{
    [SerializeField] private List<bool> _boolArray = null;

    public bool this[int index] => _boolArray[index];
}


[Serializable]
public class BoolMatrix : IEnumerable<BoolArray>
{
    [SerializeField] private List<BoolArray> _boolMatrix = null;


    public IEnumerator<BoolArray> GetEnumerator()
    {
        return _boolMatrix.GetEnumerator();
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return _boolMatrix.GetEnumerator();
    }
}