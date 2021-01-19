using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : RestartableObject
{
    public static bool IsAlive { get; private set; } = true;
    public static bool IsGrounded { get; private set; } = true;

    [SerializeField]
    private GravityDirection _startDirection = GravityDirection.DOWN;
    private GravityChangeType _gravitation;
    private MoveСontrolType _move;

    private ScreenFade _fade;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private Quaternion _newRotation;

    private float _speed = 4.5f;
    private float _rotationSpeed = 5f;
    private float _liftForce = 0.8f;  // сила, которая толкает персонажа при повороте на 90 градусов 

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private enum CharacterState { IDLE, RUN, FALL, DIE };
    private CharacterState _state
    {
        get { return (CharacterState)_animator.GetInteger("State"); }
        set { _animator.SetInteger("State", (int)value); }
    }


    private void Start()
    {
        InstantiateTouchCanvas();

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _fade = FindObjectOfType<ScreenFade>();

        _startPosition = transform.position;
        _startRotation = transform.rotation;
        
        _gravitation.GravityChanged.AddListener(OnGravityChanged);
        _gravitation.MakeStartTurn(_startDirection);

        _rigidbody.gravityScale = 40;
    }


    private void InstantiateTouchCanvas()
    {
        GameObject touchCanvas = Instantiate(Resources.Load<GameObject>("Prefabs/Level/TouchCanvas"));

        touchCanvas.AddComponent(Settings.MoveControlType);
        touchCanvas.AddComponent(Settings.GravityChangeType);

        _gravitation = touchCanvas.GetComponent<GravityChangeType>();
        _move = touchCanvas.GetComponent<MoveСontrolType>();
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, Time.deltaTime * _rotationSpeed);
    }


    private void FixedUpdate()
    {
        if (IsAlive == true)
        {
            SetIsGrounded();
            SetAnimation();
            Run();
        }
    }


    private void SetIsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);

        IsGrounded = colliders.Length > 1;
    }


    private void SetAnimation()
    {
        if (IsGrounded == true)
        {
            _state = (_move.Movement == Move.STOP) ? CharacterState.IDLE : CharacterState.RUN;
        }

        else
        {
            _state = CharacterState.FALL;
        }
    }


    private void Run()
    {
        // Инверсия, когда персонаж вверху
        int sign = (int)_move.Movement * (_gravitation.Direction == GravityDirection.UP ? -1 : 1);
        Move actualMovement = (Move)sign;

        Vector3 moveDirection = transform.right * sign;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, _speed * Time.deltaTime);

        if (actualMovement != Move.STOP)
        _sprite.flipX = actualMovement == Move.LEFT;
    }


    private void OnGravityChanged(GravityDirection lastGravityDirection)
    {
        bool rightAngle = Math.Abs(lastGravityDirection - _gravitation.Direction) % 2 == 1;

        if (rightAngle == true) // смена гравитации на 90 градусов 
            _rigidbody.AddForce(transform.up * _liftForce, ForceMode2D.Impulse); // чтобы не "цеплялся" за пол

        _newRotation = _gravitation.GetRotation();
    }


    public IEnumerator Die()
    {
        if (IsAlive == true) 
        {
            IsAlive = false;
            _state = CharacterState.DIE;

            yield return StartCoroutine(_fade.MakeFade());
            yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(1.5f, true, (result) => { _sprite.color = result; }));
            IsAlive = true;
        }
    }


    public override void Restart()
    {
        _state = CharacterState.IDLE;
        _sprite.color = new Color(255, 255, 255, 0);
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
        _gravitation.MakeStartTurn(_startDirection);
    }


    public IEnumerator Disappear()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.gravityScale = 0;

        yield return StartCoroutine(ScreenFade.ChangeAlphaChannel(-2f, false, (result) => { _sprite.color = result; }));

        Destroy(gameObject);
    }
}



