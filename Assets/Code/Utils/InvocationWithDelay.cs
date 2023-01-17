using System;
using System.Collections;
using UnityEngine;

public class InvocationWithDelay
{
    private readonly Action<bool> _action;
    private readonly float _activationDelay;
    private readonly float _deactivationDelay;

    public InvocationWithDelay(float activationDelay, float deactivationDelay, Action<bool> action)
    {
        _activationDelay = activationDelay;
        _deactivationDelay = deactivationDelay;
        _action = action;
    }

    public IEnumerator Invoke(bool activate)
    {
        yield return new WaitForSeconds(activate ? _activationDelay : _deactivationDelay);

        _action(activate);
    }
}