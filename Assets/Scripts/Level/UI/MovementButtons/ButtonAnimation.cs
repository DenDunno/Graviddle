using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonAnimation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private float _verticalOffset = 8f;
    private Vector2 _startPosition;


    private void Start()
    {
        _startPosition = transform.position;
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.position +=  _verticalOffset * transform.up;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = _startPosition;
    }


    public void OnDrag(PointerEventData eventData)
    {
    }
}