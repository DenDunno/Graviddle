using System.Collections;
using UnityEngine;


public class ArrowTrapGroup : ArrowTrapBase
{
    [SerializeField] private ArrowSpawner[] _arrowSpawners;
    [SerializeField] private BoolMatrix _arrowsShootingMatrix;
    [SerializeField] private float _rate = 2f;


    protected override IEnumerator OnShoot()
    {
        foreach (BoolArray boolArray in _arrowsShootingMatrix)
        {
            for (int i = 0 ; i < _arrowSpawners.Length; ++i)
            {
                if (boolArray[i])
                {
                    _arrowSpawners[i].SpawnArrow();
                }
            }

            yield return new WaitForSeconds(_rate);
        }
    }
}