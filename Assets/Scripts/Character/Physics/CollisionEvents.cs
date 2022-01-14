using UnityEngine;
using UnityEngine.Events;


public class CollisionEvents : MonoBehaviour
{
    [HideInInspector] public UnityEvent ObstacleEntered;
    [HideInInspector] public UnityEvent FinishEntered;


    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        TryInvokeCollisionEvent<Obstacle>(collider2d, ObstacleEntered);
        TryInvokeCollisionEvent<FinishPortal>(collider2d, FinishEntered);
    }


    private void TryInvokeCollisionEvent<T>(Collider2D collider2d, UnityEvent unityEvent)
    {
        if (collider2d.GetComponent<T>() != null)
        {
            unityEvent?.Invoke();
        }
    }
}