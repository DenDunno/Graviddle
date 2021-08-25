using UnityEngine;
using UnityEngine.UI;


public class CameraControllingTutorial : MonoBehaviour
{
    [SerializeField] private IconsTutorial _iconsTutorial = null;
    [SerializeField] private Button _pointerBack = null;
    [SerializeField] private SpriteRenderer _spriteRenderer = null;


    private void FixedUpdate()
    {
        if (_spriteRenderer.isVisible)
        {
            enabled = false;

            _iconsTutorial.ShowNextTutorialInfo();
            _pointerBack.interactable = true;
        }
    }
}
