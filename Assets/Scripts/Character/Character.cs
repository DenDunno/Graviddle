using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static bool IsAlive { get; private set; } = true;
    public static bool IsGrounded { get; private set; } = true;

    private GravityChangeType _gravitation;
    private MoveСontrolType _move;
    private ScreenFade _fade;

    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private StartPortal _startPortal;

    private float _speed = 4.5f;
    private float _speedOfRotation = 5f;
    private float _liftForce = 0.8f;  // сила, которая толкает персонажа при повороте на 90 градусов (чтобы не цеплял пол)

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
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();

        GameObject touchCanvas = Instantiate(Resources.Load<GameObject>("Prefabs/Level/TouchCanvas"));

        _gravitation = touchCanvas.GetComponent<GravityChangeType>();
        _move = touchCanvas.GetComponent<MoveСontrolType>();
        _fade = FindObjectOfType<ScreenFade>();

        _gravitation.LoadData();

        _startPortal = Resources.Load<StartPortal>("Prefabs/Level/StartPortal");
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _rigidbody.gravityScale = 40;
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
        Quaternion rotationTo = _gravitation.GetRotation();
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationTo, Time.deltaTime * _speedOfRotation);
    }

    private void Run()
    {
        if (_move.Movement != Move.STOP)
        {
            if (IsGrounded)
                _state = CharacterState.RUN;

            // Инверсия, когда персонаж вверху
            Vector3 move_direction = transform.right * (int)_move.Movement * (_gravitation.Direction == GravityDirection.UP ? -1 : 1);

            transform.position = Vector3.MoveTowards(transform.position, transform.position + move_direction, _speed * Time.deltaTime);

            switch (_gravitation.Direction)
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
            _state = CharacterState.IDLE;
    }

    private void SetIsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);

        IsGrounded = colliders.Length > 1;

        if (!IsGrounded)
            _state = CharacterState.FALL;
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

    public void OnTossingUp()
    {
        // При смене гравитации на 90 градусов персонаж "цепляется" за пол
        _rigidbody.AddForce(transform.up * _liftForce, ForceMode2D.Impulse); 
    }

    public void Restart()
    {
        _state = CharacterState.IDLE;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
        _rigidbody.velocity = Vector2.zero;
        Instantiate(_startPortal, transform.position + new Vector3(0, 0.85f, 0), transform.rotation); // портал выше персонажа на 0.85
    }
}



