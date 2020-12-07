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

    private float _time;
    private float _lerp;

    protected float _period;

    protected override void Start()
    {
        base.Start();
        _period = (float)(2 * Math.PI / _speed);
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _period)
            _time = 0;

        _lerp = (float)(1 - Math.Cos(_speed * _time)) / 2;

        transform.position = Vector3.Lerp(_start, _target, _lerp);
    }
}

