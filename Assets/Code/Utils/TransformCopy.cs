using UnityEngine;

// Purpose is not to unpack prefab, when changing prefab structure
public class TransformCopy : MonoBehaviour 
{
    [SerializeField] private Transform _target;

    private void Start()
    {
        transform.position = _target.position;
        transform.rotation = _target.rotation;
        transform.localScale = _target.localScale;
        transform.parent = _target.parent;
    }
}