using UnityEngine;

public class GravityBox : MonoBehaviourWrapper
{
    [SerializeField] private SpriteOutline _spriteOutline;
    [SerializeField] private Collider2D _collider;

    private void Awake()
    {
        SetDependencies(new IUnityCallback[]
        {
            new PhysicsInputTrigger(_collider)
        });
    }
}
