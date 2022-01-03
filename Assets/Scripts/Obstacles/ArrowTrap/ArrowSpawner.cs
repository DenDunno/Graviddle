using System.Collections.Generic;
using ModestTree;
using UnityEngine;


public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab = null;
    [SerializeField] private Transform _spawnTransform = null;
    [SerializeField] private LevelBorders _levelBorders = null;
    private readonly Stack<Arrow> _arrowsPull = new Stack<Arrow>();
    private readonly Queue<Arrow> _updatingArrows = new Queue<Arrow>();


    public void SpawnArrow()
    {
        Arrow arrow = SpawnOrPopArrow();
        arrow.transform.SetPositionAndRotation(_spawnTransform);
        _updatingArrows.Enqueue(arrow);
        arrow.Trail.ActivateTrail();
    }


    private void Update()
    {
        if (_updatingArrows.IsEmpty() == false)
        {
            if (_levelBorders.CheckIfPositionNotWithinTheLevel(_updatingArrows.Peek().transform.position))
            {
                Arrow arrowToBePulled = _updatingArrows.Dequeue();
                _arrowsPull.Push(arrowToBePulled);
                arrowToBePulled.Trail.DeactivateTrail();
            }
        }
    }


    private Arrow SpawnOrPopArrow()
    {
        return _arrowsPull.IsEmpty() ? Instantiate(_arrowPrefab) : _arrowsPull.Pop();
    }
}