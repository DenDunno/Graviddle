using System.Collections;
using UnityEngine;


public class MovingSpike : MonoBehaviour, IObstacle
{
    [SerializeField] private float _coolDown = 2f;
    [SerializeField] private float _waitingTimeOnAwake = 0;
    private readonly string _animationName = "Idle";
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();

        StartCoroutine(AnimateSpike());
    }


    private IEnumerator AnimateSpike()
    {
        yield return new WaitForSeconds(_waitingTimeOnAwake);

        while (true)
        {
            _animator.Play(_animationName);
            
            yield return new WaitForSeconds(_coolDown);
        }
    }
}