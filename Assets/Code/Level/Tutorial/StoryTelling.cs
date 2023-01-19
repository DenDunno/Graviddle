using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class StoryTelling : MonoBehaviour, IRestart
{
    [SerializeField] private StoryPart[] _storyParts;
    private bool _isShown;

    public event Action StoryEnded;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isShown == false && other.GetComponent<Character>() != null)
        {
            StartCoroutine(StartStory());
        }
    }

    private IEnumerator StartStory()
    {
        _isShown = true;

        foreach (StoryPart storyPart in _storyParts)
        {
            yield return new WaitForSeconds(storyPart.WaitTime);
            
            storyPart.Pointer.ShowHint();
        }
        
        yield return new WaitForSeconds(_storyParts[^1].Pointer.Duration);

        StoryEnded?.Invoke();
    }

    void IRestart.Restart()
    {
        StopAllCoroutines();
        _isShown = false;
        
        foreach (StoryPart storyPart in _storyParts)
        {
            storyPart.Pointer.ResetImage();
        }
    }
}