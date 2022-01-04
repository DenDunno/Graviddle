using System.Collections;
using UnityEngine;


public class ArrowTrap : ArrowTrapBase
{
    [SerializeField] private ArrowSpawner _arrowSpawner = null;


    protected override IEnumerator OnShoot()
    {
        _arrowSpawner.SpawnArrow();

        yield return null;
    }
}