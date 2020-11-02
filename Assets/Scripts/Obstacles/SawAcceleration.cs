using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawAcceleration : Saw
{
    /* 
    Взял за основу функцию f(x) = (1 - cos(a * x) ) / 2  , где a - параметр 
    В нашем случае скорость. Чем больше a, тем более "сплюснутая" функция, тем
    быстрее пила

    Область значения f = [0 , 1]
    Аргумент функции x - время
    Значение функции - пройденный путь пилы
    Период f = 2PI / a
    */

    private float time;
    private float lerp;

    protected float period;

    private void Start()
    {
        start = transform.position; // point A
        target = start + transform.right * distance * (goRight ? 1 : -1); // point B
        period = (float)(2 * Math.PI / speed);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= period)
            time = 0;

        lerp = (float)(1 - Math.Cos(speed * time)) / 2;

        transform.position = Vector3.Lerp(start, target, lerp);
    }
}

