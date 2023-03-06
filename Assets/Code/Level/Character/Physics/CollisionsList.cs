﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionsList : MonoBehaviour
{
    private readonly List<Collider2D> _colliders = new();

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        _colliders.Add(collider2d);
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        _colliders.Remove(collider2d);
    }

    public bool CheckCollision<T>() where T : MonoBehaviour
    {
        return _colliders.Any(collider2d => collider2d.GetComponent<T>() != null);
    }
}