using System.Collections;
using UnityEngine;


public class SwipeCoolDown : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler = null;
    private readonly float _coolDown = 0.5f;


    private void OnEnable()
    {
        _swipeHandler.GravityChanged += OnGravityChanged;
    }


    private void OnDisable()
    {
        _swipeHandler.GravityChanged -= OnGravityChanged;
    }


    private void OnGravityChanged(GravityDirection gravityDirection)
    {
    }


    private IEnumerator FreezeSwipeHandler()
    {
        _swipeHandler.enabled = false;

        yield return new WaitForSeconds(_coolDown);
    }
}