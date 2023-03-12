using UnityEngine;

public class GravityBox : MonoBehaviourWrapper
{
    [SerializeField] private GravityDirection _gravityDirection;
    [SerializeField] private ConstantForce2D _constantForce2D;
    [SerializeField] private BoxGravitySelection _selection;
    [SerializeField] private SpriteRenderer _outline;
    [SerializeField] private SpriteRenderer _arrow;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Canvas _canvas;

    public void Init(SwipeHandler swipeHandler)
    {
        PhysicsInputTrigger physicsInputTrigger = new(_collider);
        Gravity gravity = new(_constantForce2D, 50f, _gravityDirection);
        BoxGravityState boxGravityState = new(transform, _gravityDirection);
        BoxGravityHandler gravityHandler = new(gravity, _selection, boxGravityState);
        GravityRotation rotation = new(boxGravityState, _arrow.transform, 180, 6);
        BoxMediator boxMediator = new(physicsInputTrigger, swipeHandler, gravityHandler, new IToggleable[]
        {
            new ScalePopup(_canvas.transform, 0.5f, 0, 1),
            new ScalePopup(_outline.transform, 0.5f, 1, 1.15f)
        });

        SetDependencies(new IUnityCallback[]
        {
            gravity,
            rotation,
            _selection,
            boxMediator,
            gravityHandler,
            physicsInputTrigger,
        });
    }
}
