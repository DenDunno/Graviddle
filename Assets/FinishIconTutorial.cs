using System.Collections.Generic;
using UnityEngine;


public class FinishIconTutorial : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera = null;
    [SerializeField] private FinishPortal _finishPortal = null;
    [SerializeField] private List<GameObject> _gameplayUI = null;
    [SerializeField] private SwipeHandler _swipeHandler = null;
    [SerializeField] private IconsTutorial _iconsTutorial = null;

    private readonly float _epsilon = 0.4f;


    private void Update()
    {
        if (Vector2.Distance(_mainCamera.transform.position, _finishPortal.transform.position) <= _epsilon)
        {
            enabled = false;
            _gameplayUI.ForEach(ui => ui.gameObject.SetActive(true));
            _iconsTutorial.ShowNextTutorialInfo();
            _swipeHandler.enabled = true;
        }
    }
}
