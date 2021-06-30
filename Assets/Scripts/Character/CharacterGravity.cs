using UnityEngine;


public class CharacterGravity : MonoBehaviour
{
    public int MovementInversion { get; private set; } = 1;

    [SerializeField] private SwipeHandler _swipeHandler = null;

    private readonly float _rotationSpeed = 5f;
    private Quaternion _targetRotation;


    private void Start()
    {
        Physics2D.gravity = new Vector2(0, -1);
    }


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
        GravityData gravityData = GravityDataPresenter.GravityData[(int)gravityDirection];

        Physics2D.gravity = gravityData.GravityVector;
        _targetRotation = gravityData.Rotation;

        MovementInversion = (gravityDirection == GravityDirection.Up ? -1 : 1);
    }
}





