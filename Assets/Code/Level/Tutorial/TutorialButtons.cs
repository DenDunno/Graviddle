using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    [SerializeField] private StoryTelling _storyTelling;
    [SerializeField] private Canvas _ui;

    private void OnEnable()
    {
        _storyTelling.StoryEnded += OnStoryEnded;
    }
    
    private void OnDisable()
    {
        _storyTelling.StoryEnded -= OnStoryEnded;
    }

    private void OnStoryEnded()
    {
        _ui.gameObject.SetActive(true);
    }
}