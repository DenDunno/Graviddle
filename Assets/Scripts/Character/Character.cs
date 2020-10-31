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
    public static int num_of_rotations = 0;

    private TouchController touch_controller;
    private FadeController fade_controller;

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

    public bool IsAlive { get; private set; } = true;
    public bool IsGrounded { get; private set; } = true;


    private GravityDirection current_direction;
    private Dictionary<GravityDirection, Quaternion> gravDir_to_Quaternion;

    private class NewGravitation
    {
        public GravityDirection direction;
        public Vector2 gravitaion_vector;

        public NewGravitation(GravityDirection d, Vector2 g_v)
        {
            direction = d;
            gravitaion_vector = g_v;
        }
    }

    private Dictionary<Swipe, NewGravitation> swipe_to_new_gravitaion =
        new Dictionary<Swipe, NewGravitation>()
        {
             {Swipe.UP    , new NewGravitation (GravityDirection.UP     ,  new Vector2(0  ,  1)) },
             {Swipe.DOWN  , new NewGravitation (GravityDirection.DOWN   ,  new Vector2(0  , -1)) },
             {Swipe.LEFT  , new NewGravitation (GravityDirection.LEFT   ,  new Vector2(-1 ,  0)) },
             {Swipe.RIGHT , new NewGravitation (GravityDirection.RIGHT  ,  new Vector2(1  ,  0)) }
        };


    [SerializeField]
    private Swipe key_to_start_gravitation = Swipe.DOWN;
    private NewGravitation start_grav;
    private Vector3 start_position;
    private Quaternion start_rotation;

    private StartPortal start_portal;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        touch_controller = FindObjectOfType<TouchController>();
        fade_controller = FindObjectOfType<FadeController>();
        start_portal = Resources.Load<StartPortal>("Prefabs/Level/Start");

        gravDir_to_Quaternion = new Dictionary<GravityDirection, Quaternion>();
        for (int dir = 0, ang = -90; dir < 4; ++dir, ang += 90)
            gravDir_to_Quaternion[(GravityDirection)dir] = Quaternion.AngleAxis(ang, transform.forward);

        start_grav = swipe_to_new_gravitaion[key_to_start_gravitation];
        start_position = transform.position;
        start_rotation = transform.rotation;

        current_direction = start_grav.direction;
        Physics2D.gravity = start_grav.gravitaion_vector;
        rigidbody.gravityScale = 40;

        num_of_rotations = 0;
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
            Vector3 move_direction = transform.right * (int)touch_controller.Character_movement * (current_direction == GravityDirection.UP ? -1 : 1);

            transform.position = Vector3.MoveTowards(transform.position, transform.position + move_direction, speed * Time.deltaTime);

            switch (current_direction)
            {
                case GravityDirection.DOWN:
                    sprite.flipX = move_direction.x < 0.0F;
                    break;

                case GravityDirection.UP:
                    sprite.flipX = move_direction.x > 0.0F;
                    break;

                case GravityDirection.RIGHT:
                    sprite.flipX = move_direction.y < 0.0F;
                    break;

                case GravityDirection.LEFT:
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


    public void ChangeGravity()
    {
        NewGravitation newGravitation = swipe_to_new_gravitaion[touch_controller.Swipe];

        int rotation_angle = (int)Math.Abs(Quaternion.Angle(gravDir_to_Quaternion[current_direction], gravDir_to_Quaternion[newGravitation.direction]));

        if (rotation_angle == 90)
            rigidbody.AddForce(transform.up * lift_force, ForceMode2D.Impulse); // При смене гравитации на 90 градусов персонаж "цепляется" за пол

        Physics2D.gravity = newGravitation.gravitaion_vector;
        current_direction = newGravitation.direction;

        num_of_rotations++;
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



