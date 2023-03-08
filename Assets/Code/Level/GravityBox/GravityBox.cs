using UnityEngine;

public class GravityBox : MonoBehaviourWrapper
{
    [SerializeField] private ConstantForce2D _constantForce2D;
    [SerializeField] private SpriteRenderer _outline;
    [SerializeField] private BoxGravityView _view;
    [SerializeField] private SpriteRenderer _arrow;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Canvas _canvas;

    public void Init(SwipeHandler swipeHandler)
    {
        BoxGravityState gravityState = new();
        Gravity gravity = new(_constantForce2D, 50f);
        PhysicsInputTrigger physicsInputTrigger = new(_collider);
        BoxGravity boxGravity = new(gravity, transform, _view, gravityState);
        GravityRotation rotation = new(gravityState, _arrow.transform, 180, 6);
        BoxMediator boxMediator = new(physicsInputTrigger, swipeHandler, boxGravity, new IToggleable[]
        {
            new ScalePopup(_canvas.transform, 0.5f, 0, 1),
            new ScalePopup(_outline.transform, 0.5f, 1, 1.15f)
        });

        SetDependencies(new IUnityCallback[]
        {
            _view,
            gravity,
            rotation,
            boxMediator,
            boxGravity,
            physicsInputTrigger,
        });
    }
}
