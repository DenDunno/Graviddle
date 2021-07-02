using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour , IRestartableObject
{
    [SerializeField] private UnityEvent Died = null;

    private Rigidbody2D _rigidbody;

    private Vector3 _startPosition;
    private Quaternion _startRotation;


    private void Awake()
    {
        CharacterStates.Init(this , Died);

        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _rigidbody = GetComponent<Rigidbody2D>();
    }


    void IRestartableObject.Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = new Vector2(0, 0);
    }
}



