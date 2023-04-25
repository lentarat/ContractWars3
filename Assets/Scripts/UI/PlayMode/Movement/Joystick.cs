using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics.CodeAnalysis;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _handle;
    [SerializeField] private Image _button;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _maximumRadius = 100;
    public Vector3 Direction { get; private set; }

    private Vector3 _startPoint = Vector3.zero;
 

    private void Awake()
    {
        _startPoint = _handle.transform.position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_button.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _button.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _button.rectTransform.sizeDelta.y);

            Direction = new Vector3(pos.x * 2, pos.y * 2, 0f);
            Direction = (Direction.magnitude > 1f) ? Direction.normalized : Direction;

            _handle.rectTransform.anchoredPosition = new Vector3(Direction.x * _maximumRadius, Direction.y * _maximumRadius);
        }

        Debug.Log($"X : {Direction.x}, Y :  {Direction.y}");
     
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("test");
        _handle.transform.position = _startPoint;
        Direction = Vector3.zero;
        //UpdateHandlePosition(Vector3.zero + transform.position);
    }

}