using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class StoryTelling : MonoBehaviour, IRestart
{
    [SerializeField] private StoryPart[] _storyParts;
    private CircleCollider2D _collider;
    private bool _storyStarted;

    public event Action StoryEnded;

    private void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_storyStarted == false && other.GetComponent<Character>() != null)
        {
            StartCoroutine(StartStory());
        }
    }

    private IEnumerator StartStory()
    {
        _storyStarted = true;

        foreach (StoryPart storyPart in _storyParts)
        {
            yield return new WaitForSeconds(storyPart.WaitTime);
            
            storyPart.Pointer.ShowHint();
        }
        
        yield return new WaitForSeconds(_storyParts.Last().Pointer.Duration);

        StoryEnded?.Invoke();
    }

    void IRestart.Restart()
    {
        StopAllCoroutines();
        
        _storyStarted = false;
        _collider.ClearCollisionList();

        foreach (StoryPart storyPart in _storyParts)
        {
            storyPart.Pointer.ResetImage();
        }
    }
}