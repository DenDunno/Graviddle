using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

public enum CharState
{
    Idle, // = 0
    Run,  // = 1
    Fall, // = 2
    Die   // = 4
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
    private float lift_force = 0.8f;

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public static bool IsAlive = true;
    private bool isGrounded = true;
    

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
            CheckSwipe();
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
            if (isGrounded)
                State = CharState.Run;

            Vector3 move_direction = transform.right * (int)touch_controller.Character_movement * (current_direction == Gravity_direction.UP ? -1 : 1); // Инверсия, когда персонаж вверху

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

        else if (isGrounded)
            State = CharState.Idle;
    }


    private void Change_gravity(NewGravitation newGravitation)
    {
        int rotation_angle = (int)Math.Abs(Quaternion.Angle(gravDir_to_Quaternion[current_direction], gravDir_to_Quaternion[newGravitation.direction]));

        if (rotation_angle == 90)
            rigidbody.AddForce(transform.up * lift_force, ForceMode2D.Impulse); // При смене гравитации на 90 градусов перс "цепляется" за пол

        Physics2D.gravity = newGravitation.gravitaion_vector;
        current_direction = newGravitation.direction;

        touch_controller.IsSwipe = false;
    }


    private void CheckSwipe()
    {
        if (touch_controller.IsSwipe)
            Change_gravity(swipe_to_new_gravitaion[touch_controller.Swipe]);
    }


    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        isGrounded = colliders.Length > 1; 
        
        if (!isGrounded)
        State = CharState.Fall;
    }


    public void Die()
    {
        if (IsAlive) // проверка на "смерть во время смерти" (Когда летишь, будучи мертвым, и натыкаешься на еще что-то)
        {
            IsAlive = false;
            State = CharState.Die;
            StartCoroutine(fade_controller.Make_Fade());
        }
    }


    public void Restart()
    {
        State = CharState.Idle;
        transform.position = start_position;
        transform.rotation = start_rotation;
        rigidbody.velocity = Vector2.zero;
        current_direction = start_grav.direction;
        Physics2D.gravity = start_grav.gravitaion_vector;
        Instantiate(start_portal, transform.position + new Vector3(0, 0.85f, 0), transform.rotation); // портал выше персонажа на 0.85
    }
}


