﻿using System;
using UnityEngine;

public class PhysicsInputTrigger : IUpdate
{
    private readonly Collider2D _targetCollider;
    private readonly Camera _camera;
    private bool _isHolding;
    
    public PhysicsInputTrigger(Collider2D targetCollider)
    {
        _targetCollider = targetCollider;
        _camera = Camera.main;
    }

    public event Action Entered;
    
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider2D = Physics2D.OverlapPoint(mousePosition);
            
            if (collider2D == _targetCollider)
            {
                Debug.Log("Enter");
                _isHolding = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_isHolding)
            {
                Debug.Log("Exit");
                _isHolding = false;
            }
        }
    }
}