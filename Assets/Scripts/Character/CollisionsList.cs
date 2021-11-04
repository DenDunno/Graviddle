using System.Collections.Generic;
using UnityEngine;


public class CollisionsList : MonoBehaviour
{
    private readonly List<Collider2D> _colliders = new List<Collider2D>();

    public IReadOnlyList<Collider2D> Colliders => _colliders;


    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        _colliders.Add(collider2d);
    }


    private void OnTriggerExit2D(Collider2D collider2d)
    {
        _colliders.Remove(collider2d);
    }
}