using UnityEngine;

public enum Alignment { Top, Down, Right, Left }

public class HiddenUIAlignment 
{
    private readonly RectTransform _transform;
    private readonly RectTransform _observable;
    private readonly Alignment _alignment;
    private readonly Canvas _canvas;

    public HiddenUIAlignment(RectTransform transform, RectTransform observable, Alignment alignment, Canvas canvas)
    {
        _observable = observable;
        _transform = transform;
        _alignment = alignment;
        _canvas = canvas;
    }

    public void Execute()
    {
        CopySize();
        CopyPosition();
        Align();
    }

    private void CopySize()
    {
        _transform.sizeDelta = new Vector2(_observable.rect.width, _observable.rect.height);
    }
    
    private void CopyPosition()
    {
        _transform.position = _observable.position;
    }

    private void Align()
    {
        Vector2 canvasSize = _canvas.GetComponent<RectTransform>().rect.size;
        Vector2 screenOffset = (canvasSize + _transform.rect.size) / 2f;
        Vector2 targetPosition = _transform.anchoredPosition;
        
        switch (_alignment)
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
        
        _transform.anchoredPosition = targetPosition;
    }
}