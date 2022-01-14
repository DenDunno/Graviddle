//////////////////////////////////////////////////////
// MK Glow Asteroid Spawner         				//
//					                                //
// Created by Michael Kremmel                       //
// www.michaelkremmel.de                            //
// Copyright © 2017 All rights reserved.            //
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Glow.Example
{
    public class AsteroidSpawner : MonoBehaviour
    {
        private static readonly float _spawnTime = 0.125f;
        [SerializeField]
        private GameObject _asteroidObject;

        [SerializeField]
        private int _maxObjects;

        private int _spawnedObjects;

        private float _time;

        private void Update()
        {
            if(_spawnedObjects < _maxObjects)
            {
                if(_time > _spawnTime)
                {
                    Instantiate(_asteroidObject, transform.position, Quaternion.identity);
                    ++_spawnedObjects;
                    _time = 0;
                }
                _time += Time.smoothDeltaTime;
            }
        }
    }
}
