using System.Collections.Generic;
using UnityEngine;


public class IconsTutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tutorialPanels = null;
    [SerializeField] private GameObject _cameraIcon = null;
    private int _currentTutorialPanel = 0;
    

    public void ShowNextTutorialInfo()
    {
        _tutorialPanels.ForEach(tutorPanel => tutorPanel.gameObject.SetActive(false));

        ++_currentTutorialPanel;
        
        if (_currentTutorialPanel >= _tutorialPanels.Count)
        {
            _cameraIcon.gameObject.SetActive(true);
            _tutorialPanels[_tutorialPanels.Count - 1].SetActive(true);
        }

        else
        {
            _tutorialPanels[_currentTutorialPanel].gameObject.SetActive(true);
        }
    }
}