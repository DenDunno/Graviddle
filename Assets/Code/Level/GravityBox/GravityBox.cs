using UnityEngine;

public class GravityBox : MonoBehaviourWrapper
{
    [SerializeField] private ConstantForce2D _constantForce2D;
    [SerializeField] private SpriteRenderer _outline;
    [SerializeField] private BoxGravityView _view;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Canvas _canvas;

    public void Init(SwipeHandler swipeHandler)
    {
        Gravity gravity = new(_constantForce2D, 10f);
        BoxGravity boxGravity = new(gravity, transform, _view);
        PhysicsInputTrigger physicsInputTrigger = new(_collider);
        BoxInput boxInput = new(physicsInputTrigger, swipeHandler, boxGravity, new IToggleable[]
        {
            new ScalePopup(_canvas.transform, 0.5f, 0, 1),
            new ScalePopup(_outline.transform, 0.5f, 1, 1.15f)
        });

        SetDependencies(new IUnityCallback[]
        {
            _view,
            gravity,
            boxInput,
            boxGravity,
            physicsInputTrigger,
        });
    }
}
