using System;
using UnityEngine;

public class PhysicsInputTrigger : IUpdate
{
    private readonly Collider2D[] _results = new Collider2D[5];
    private readonly Collider2D _targetCollider;
    private readonly Camera _camera;
    private bool _isHolding;

    public PhysicsInputTrigger(Collider2D targetCollider)
    {
        _targetCollider = targetCollider;
        _camera = Camera.main;
    }

    public event Action Entered;
    public event Action Exited;
    
    void IUpdate.Update()
    {
        TryInvokeEnterTrigger();
        TryInvokeExitTrigger();
    }

    private void TryInvokeEnterTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            int numColliders = Physics2D.OverlapPointNonAlloc(mousePosition, _results);
            
            for (int i = 0; i < numColliders; i++)
            {
                if (_results[i] == _targetCollider)
                {
                    Entered?.Invoke();
                    _isHolding = true;
                    break;
                }
            }
        }
    }

    private void TryInvokeExitTrigger()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_isHolding)
            {
                Exited?.Invoke();
                _isHolding = false;
            }
        }
    }
}