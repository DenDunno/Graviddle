using System;
using UnityEngine;

public class PhysicsEventBroadcaster : MonoBehaviour
{
    public event Action<Collider2D> Entered;
    public event Action<Collider2D> Exited;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        Entered?.Invoke(collider2d);
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        Exited?.Invoke(collider2d);
    }
}