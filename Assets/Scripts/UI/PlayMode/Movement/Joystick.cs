using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _handle;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private float _maximumRadius;
    public Vector2 Direction { get; private set; }

    private Vector2 _startPoint = Vector2.zero;
 

    private void Awake()
    {
        _startPoint = transform.position;
        _maximumRadius = gameObject.GetComponent<RectTransform>().sizeDelta.y * _canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float distance = Vector3.Distance(_startPoint, eventData.position);
        //Direction = Vector2.(_startPoint, eventData.position);
        distance = Mathf.Clamp(distance, 0, _maximumRadius);
        Vector3 direction = (new Vector3(eventData.position.x, eventData.position.y, 0) - transform.position).normalized;
        Direction = direction;
        Debug.Log(Direction);
        //Debug.Log($"[{GetType().Name}][OnDrag] Distance: {distance}");
        if (distance > _maximumRadius)
        {
            UpdateHandlePosition(eventData.position);
        }
        else
        {
            UpdateHandlePosition(direction * distance + transform.position); 
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("test");
        _handle.transform.position = Vector3.zero;
        Direction = Vector2.zero;
        UpdateHandlePosition(Vector3.zero + transform.position);
    }

    private void UpdateHandlePosition(Vector3 clampedHandlePosition)
    {
        //Direction = _handle.transform.position.normalized;

        _handle.transform.position = clampedHandlePosition;
    }
}