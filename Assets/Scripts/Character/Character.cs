using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public static UnityEvent TossingUp = new UnityEvent();
    public static bool IsAlive { get; private set; } = true;
    public static bool IsGrounded { get; private set; } = true;

    [SerializeField]
    private  GravityDirection _startDirection = GravityDirection.DOWN;
    private GravityChangeType _gravitation;
    private MoveСontrolType _move;
    private ScreenFade _fade;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private StartPortal _startPortal;

    private float _speed = 4.5f;
    private float _speedOfRotation = 5f;
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
        IsAlive = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        
        InstantiateTouchCanvas();
        _fade = FindObjectOfType<ScreenFade>();
        
        _startPortal = Resources.Load<StartPortal>("Prefabs/Level/StartPortal");
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _rigidbody.gravityScale = 40;
        
        TossingUp.AddListener(OnTossingUp);
        _gravitation.MakeStartTurn(_startDirection);
    }


    private void FixedUpdate()
    {
        if (IsAlive)
        {
            Run();
            SetIsGrounded();
        }
    }


    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _gravitation.GetRotation(), Time.deltaTime * _speedOfRotation);
    }


    private void Run()
    {
        if (_move.Movement != Move.STOP)
        {
            if (IsGrounded)
                _state = CharacterState.RUN;

            // Инверсия, когда персонаж вверху
            Vector3 moveDirection = transform.right * (int)_move.Movement * (_gravitation.Direction == GravityDirection.UP ? -1 : 1);

            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDirection, _speed * Time.deltaTime);

            switch (_gravitation.Direction)
            {
                case GravityDirection.DOWN:
                    _sprite.flipX = moveDirection.x < 0.0F;
                    break;

                case GravityDirection.UP:
                    _sprite.flipX = moveDirection.x > 0.0F;
                    break;

                case GravityDirection.RIGHT:
                    _sprite.flipX = moveDirection.y < 0.0F;
                    break;

                case GravityDirection.LEFT:
                    _sprite.flipX = moveDirection.y > 0.0F;
                    break;

            }
        }

        else if (IsGrounded)
            _state = CharacterState.IDLE;
    }


    private void SetIsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.15f);

        IsGrounded = colliders.Length > 1;

        if (!IsGrounded)
            _state = CharacterState.FALL;
    }


    private void OnTossingUp()
    {
        // При смене гравитации на 90 градусов персонаж "цепляется" за пол
        _rigidbody.AddForce(transform.up * _liftForce, ForceMode2D.Impulse); 
    }


    public IEnumerator Die()
    {
        if (IsAlive) // проверка на "смерть во время смерти" (Когда летишь, будучи мертвым, и натыкаешься на еще что-то)
        {
            IsAlive = false;
            _state = CharacterState.DIE;

            yield return StartCoroutine(_fade.MakeFade());
            IsAlive = true;
        }
    }


    public void Restart()
    {
        _state = CharacterState.IDLE;
        _sprite.color = new Color(255, 255, 255, 0); // делаем прозрачным, чтобы плавно вернуть обратно
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
        _gravitation.MakeStartTurn(_startDirection);
        Instantiate(_startPortal, transform.position + transform.up * 0.8f, transform.rotation);
    }


    public void Disappear()
    {
        StartCoroutine(ScreenFade.ChangeAlphaChannel(-2f, false, (result) => { _sprite.color = result; }));
    }


    private void InstantiateTouchCanvas()
    {
        GameObject touchCanvas = Instantiate(Resources.Load<GameObject>("Prefabs/Level/TouchCanvas"));        

        switch (Settings.MoveType)
        {
            case MoveTypeEnum.TOUCH:
                touchCanvas.AddComponent<TouchHandler>();
                break;

            case MoveTypeEnum.BUTTONS:
                touchCanvas.AddComponent<ButtonsControl>();
                break;
        }

        switch (Settings.GravityChangeType)
        {
            case GravityChangeTypeEnum.SWIPE:
                touchCanvas.AddComponent<SwipeHandler>();
                break;

            case GravityChangeTypeEnum.JOYSTICK:
                touchCanvas.AddComponent<JoystickHandler>();
                break;
        }

        _gravitation = touchCanvas.GetComponent<GravityChangeType>();
        _move = touchCanvas.GetComponent<MoveСontrolType>();
    }
}



