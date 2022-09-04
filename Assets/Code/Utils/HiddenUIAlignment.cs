using System.Collections;
using UnityEngine;


[RequireComponent(typeof(RectTransform))]
public class HiddenUIAlignment : MonoBehaviour
{
    [SerializeField] private RectTransform _observableRect;
    [SerializeField] private Alignment _anchorPreset;
    [SerializeField] private Canvas _canvas;
    private RectTransform _rectTransform;

    private enum Alignment { Top, Down, Right, Left }
    
    
    private IEnumerator Start()
    {
        yield return null;
        _rectTransform = transform as RectTransform;
        CopySize();
        CopyPosition();
        Align();
    }


    private void CopySize()
    {
        _rectTransform.sizeDelta = new Vector2(_observableRect.rect.width, _observableRect.rect.height);
    }

    
    private void CopyPosition()
    {
        _rectTransform.transform.position = _observableRect.transform.position;
    }


    private void Align()
    {
        Vector2 canvasSize = _canvas.GetComponent<RectTransform>().rect.size;
        Vector2 screenOffset = (canvasSize + _rectTransform.rect.size) / 2f;
        Vector2 targetPosition = _rectTransform.anchoredPosition;
        
        switch (_anchorPreset)
        {
            case Alignment.Right:
                targetPosition.x = screenOffset.x;
                break;
            case Alignment.Left:
                targetPosition.x = -screenOffset.x;
                break;
            case Alignment.Top:
                targetPosition.y = screenOffset.y;
                break;
            case Alignment.Down:
                targetPosition.y = -screenOffset.y;
                break;
        }
        
        _rectTransform.anchoredPosition = targetPosition;
    }
}