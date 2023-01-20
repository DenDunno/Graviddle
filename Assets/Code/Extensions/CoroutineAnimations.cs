using System;
using System.Collections;
using UnityEngine;

public static class CoroutineAnimations
{
    public static IEnumerator PlayPingPong(float start, float target, Action<float> action, float speed = 1)
    {
        float current = start;
        
        while (true)
        {
            current += speed * Time.deltaTime;

            if (speed < 0 && current <= start || speed > 0 && current >= target)
            {
                speed = -speed;
            }

            action(speed);
            
            yield return null;
        }
    }
}