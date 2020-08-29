using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;

public class Moving_saw : Obstacle
{    
    public Transform Start_of_track;
    public Transform End_of_track;

    private Vector3 start;
    private Vector3 target;
    private Vector3 temp;

    [SerializeField]
    protected float speed = 4;
    private float epsilon = 0.01f;


    private void Start()
    {
        start = Start_of_track.position;
        target = End_of_track.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target) <= epsilon)
            Change_target (ref target);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }


    protected virtual void Change_target(ref Vector3 target)
    {
        temp = start;
        start = target;
        target = temp;
    }
}



/*
 public Transform start_of_track;
    public Transform end_of_track;
    private Transform temp;

    private Vector2 half_distance;
    private double distance;
    private double time_for_max_speed;
    private double current_time;

    [SerializeField]
    private double max_speed = 6;
    private double start_speed = 0;
    private double acceleration;
    private double current_speed;

    private bool inside_the_middle = false;

    private float epsilon = 0.05f;

    private void Start()
    {
        distance = Vector2.Distance(start_of_track.position, end_of_track.position);
        acceleration = (max_speed * max_speed - start_speed * start_speed) / distance; // (a = (V ^ 2 - V0 ^ 2) / 2 * S)
        time_for_max_speed = (max_speed - start_speed) / acceleration;                 // (t = (V - V0) / a
        half_distance = (start_of_track.position + end_of_track.position) / 2;
        // t - время, за которое набирается максимальная скорость (проходит половину пути)
        // a - ускорение, нужное, чтобы набрать max_speed на distance / 2
    }

   
    private void Update()
    {
        if (Vector2.Distance(transform.position, half_distance) <= epsilon && !inside_the_middle)
        {
            inside_the_middle = true;
            StartCoroutine(Change_acceleration());
        }
       
        current_time = Time.time % time_for_max_speed;
        current_speed = start_speed + acceleration * current_time;

        if (Vector2.Distance(transform.position, end_of_track.position) == 0)
        {
            start_speed = 0;
            acceleration = -acceleration;
            
            temp = start_of_track;
            start_of_track = end_of_track;
            end_of_track = temp;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, end_of_track.position, (float)current_speed * Time.deltaTime);
    }

     private IEnumerator Change_acceleration()
    {
        start_speed = max_speed;
        acceleration = -acceleration;
        yield return new WaitForSeconds(0.5f);
        inside_the_middle = false;
    }
 */
