using UnityEngine;

public class TutorialButtons : MonoBehaviour
{
    [SerializeField] private StoryTelling _storyTelling;
    [SerializeField] private UI _ui;

    private void Start()
    {
        _ui.HideAll();
    }

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
        _ui.Show<GameplayPanel>();
    }
}