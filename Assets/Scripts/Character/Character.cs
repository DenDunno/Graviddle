using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharState
{
    IDLE, // = 0
    RUN,  // = 1
    FALL, // = 2
    DIE   // = 4
}


public enum GravityDirection
{
    LEFT,
    DOWN,
    RIGHT,
    UP
}


public class Character : MonoBehaviour
{
    public static int NumOfRotations = 0;

    private TouchController _touchController;
    private FadeController _fadeController;

    private float _speed = 4.5f;
    private float _speedOfRotation = 5f;
    private float _liftForce = 0.8f;      // сила, которая толкает персонажа при повороте на 90 градусов (чтобы не цеплял пол)

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private CharState State
    {
        get { return (CharState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }

    public bool IsAlive { get; private set; } = true;
    public bool IsGrounded { get; private set; } = true;


    private GravityDirection _currentDirection;
    


    [SerializeField]
    private Swipe _startSwipe = Swipe.DOWN;
    private NewGravitation _startGravitation;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private StartPortal _startPortal;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _touchController = FindObjectOfType<TouchController>();
        _fadeController = FindObjectOfType<FadeController>();
        _startPortal = Resources.Load<StartPortal>("Prefabs/Level/Start");
        _startGravitation = Gravitation.SwipeToNewGravitaion[_startSwipe];
        _startPosition = transform.position;
        _startRotation = transform.rotation;

        _currentDirection = _startGravitation.Direction;
        Physics2D.gravity = _startGravitation.GravitaionVector;
        _rigidbody.gravityScale = 40;

        NumOfRotations = 0;
    }


    private void FixedUpdate()
    {
        if (IsAlive)
        {
            Run();
            CheckGround();
        }
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Gravitation.DirectionToQuaternion[_currentDirection], 
            Time.deltaTime * _speedOfRotation);
    }


    private void Run()
    {
        if (_touchController.Character_movement != Movement.STOP)
        {
            if (IsGrounded)
                State = CharState.RUN;

            // Инверсия, когда персонаж вверху
            Vector3 move_direction = transform.right * (int)_touchController.Character_movement * (_currentDirection == GravityDirection.UP ? -1 : 1);

            transform.position = Vector3.MoveTowards(transform.position, transform.position + move_direction, _speed * Time.deltaTime);

            switch (_currentDirection)
            {
                case GravityDirection.DOWN:
                    _sprite.flipX = move_direction.x < 0.0F;
                    break;

                case GravityDirection.UP:
                    _sprite.flipX = move_direction.x > 0.0F;
                    break;

                case GravityDirection.RIGHT:
                    _sprite.flipX = move_direction.y < 0.0F;
                    break;

                case GravityDirection.LEFT:
                    _sprite.flipX = move_direction.y > 0.0F;
                    break;

            }
        }

        else if (IsGrounded)
            State = CharState.IDLE;
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        IsGrounded = colliders.Length > 1;

        if (!IsGrounded)
            State = CharState.FALL;
    }


    public void ChangeGravity()
    {
        NewGravitation newGravitation = Gravitation.SwipeToNewGravitaion[_touchController.Swipe];

        Quaternion     bnvb          bnmmm,,,,,..mm 
        int rotation_angle = (int)Math.Abs(Quaternion.Angle(Gravitation.DirectionToQuaternion[_currentDirection], Gravitation.DirectionToQuaternion[newGravitation.Direction]));

        if (rotation_angle == 90)
            _rigidbody.AddForce(transform.up * _liftForce, ForceMode2D.Impulse); // При смене гравитации на 90 градусов персонаж "цепляется" за пол

        Physics2D.gravity = newGravitation.GravitaionVector;
        _currentDirection = newGravitation.Direction;

        NumOfRotations++;
    }


    public IEnumerator Die()
    {
        if (IsAlive) // проверка на "смерть во время смерти" (Когда летишь, будучи мертвым, и натыкаешься на еще что-то)
        {
            IsAlive = false;
            State = CharState.DIE;

            yield return StartCoroutine(_fadeController.Make_Fade());

            IsAlive = true;
        }
    }


    public void Restart()
    {
        State = CharState.IDLE;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
        _currentDirection = _startGravitation.Direction;
        Physics2D.gravity = _startGravitation.GravitaionVector;

        Instantiate(_startPortal, transform.position + new Vector3(0, 0.85f, 0), transform.rotation); // портал выше персонажа на 0.85
    }
}



