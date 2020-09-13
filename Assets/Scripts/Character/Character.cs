using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;

public enum CharState
{
    IDLE, // = 0
    RUN,  // = 1
    FALL, // = 2
    DIE   // = 4
}


public enum Gravity_direction
{
    LEFT,
    DOWN,
    RIGHT,
    UP
}


public class Character : MonoBehaviour
{
    private Touch_controller touch_controller;
    private Fade_controller fade_controller;

    private float speed = 4.5f;
    private float speed_of_rotation = 5f;
    private float lift_force = 0.8f;      // сила, которая толкает персонажа при повороте на 90 градусов (чтобы не цеплял пол)

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public bool IsAlive    { get; private set; } = true;
    public bool IsGrounded { get; private set; } = true;


    private Gravity_direction current_direction;
    private Dictionary <Gravity_direction, Quaternion> gravDir_to_Quaternion;

    private class NewGravitation
    {
        public Gravity_direction direction;
        public Vector2 gravitaion_vector;

        public NewGravitation (Gravity_direction d , Vector2 g_v)
        {
            direction = d;
            gravitaion_vector = g_v;
        }
    }

    private Dictionary<Swipe, NewGravitation> swipe_to_new_gravitaion =
        new Dictionary<Swipe, NewGravitation>()
        {
             {Swipe.UP    , new NewGravitation (Gravity_direction.UP     ,  new Vector2(0  ,  1)) },
             {Swipe.DOWN  , new NewGravitation (Gravity_direction.DOWN   ,  new Vector2(0  , -1)) },
             {Swipe.LEFT  , new NewGravitation (Gravity_direction.LEFT   ,  new Vector2(-1 ,  0)) },
             {Swipe.RIGHT , new NewGravitation (Gravity_direction.RIGHT  ,  new Vector2(1  ,  0)) }
        };


    [SerializeField]
    private Swipe key_to_start_gravitation = Swipe.DOWN;
    private NewGravitation start_grav;
    private Vector3 start_position;
    private Quaternion start_rotation;

    private Start_portal start_portal;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        touch_controller = FindObjectOfType<Touch_controller>();
        fade_controller = FindObjectOfType<Fade_controller>();
        start_portal = Resources.Load<Start_portal>("Prefabs/Level/Start");

        gravDir_to_Quaternion = new Dictionary<Gravity_direction, Quaternion>();
        for (int dir = 0, ang = -90; dir < 4; ++dir, ang += 90)
            gravDir_to_Quaternion[(Gravity_direction)dir] = Quaternion.AngleAxis(ang, transform.forward);

        start_grav = swipe_to_new_gravitaion[key_to_start_gravitation];
        start_position = transform.position;
        start_rotation = transform.rotation;

        current_direction = start_grav.direction;
        Physics2D.gravity = start_grav.gravitaion_vector;
        rigidbody.gravityScale = 40;
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
        transform.rotation = Quaternion.Lerp(transform.rotation, gravDir_to_Quaternion[current_direction], Time.deltaTime * speed_of_rotation);
    }


    private void Run()
    {
        if (touch_controller.Character_movement != Movement.STOP)
        {
            if (IsGrounded)
                State = CharState.RUN;

            // Инверсия, когда персонаж вверху
            Vector3 move_direction = transform.right * (int)touch_controller.Character_movement * (current_direction == Gravity_direction.UP ? -1 : 1);

            transform.position = Vector3.MoveTowards(transform.position, transform.position + move_direction, speed * Time.deltaTime);

            switch (current_direction)
            {
                case Gravity_direction.DOWN:
                    sprite.flipX = move_direction.x < 0.0F;
                    break;

                case Gravity_direction.UP:
                    sprite.flipX = move_direction.x > 0.0F;
                    break;

                case Gravity_direction.RIGHT:
                    sprite.flipX = move_direction.y < 0.0F;
                    break;

                case Gravity_direction.LEFT:
                    sprite.flipX = move_direction.y > 0.0F;
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


    public void Change_gravity()
    {
        NewGravitation newGravitation = swipe_to_new_gravitaion[touch_controller.Swipe];

        int rotation_angle = (int)Math.Abs(Quaternion.Angle(gravDir_to_Quaternion[current_direction], gravDir_to_Quaternion[newGravitation.direction]));

        if (rotation_angle == 90)
            rigidbody.AddForce(transform.up * lift_force, ForceMode2D.Impulse); // При смене гравитации на 90 градусов персонаж "цепляется" за пол

        Physics2D.gravity = newGravitation.gravitaion_vector;
        current_direction = newGravitation.direction;
    }


    public IEnumerator Die()
    {
        if (IsAlive) // проверка на "смерть во время смерти" (Когда летишь, будучи мертвым, и натыкаешься на еще что-то)
        {
            IsAlive = false;
            State = CharState.DIE;

            yield return StartCoroutine(fade_controller.Make_Fade());

            IsAlive = true;
        }
    }


    public void Restart()
    {
        State = CharState.IDLE;
        transform.position = start_position;
        transform.rotation = start_rotation;
        rigidbody.velocity = Vector2.zero;
        current_direction = start_grav.direction;
        Physics2D.gravity = start_grav.gravitaion_vector;

        Instantiate(start_portal, transform.position + new Vector3(0, 0.85f, 0), transform.rotation); // портал выше персонажа на 0.85
    }
}



