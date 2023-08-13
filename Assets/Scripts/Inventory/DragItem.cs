using UnityEngine;
using UnityEngine.EventSystems;
public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    public Slot ParentSlot;
    private Canvas _mainCanvs;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Transform _parent;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvs = GetComponentInParent<Canvas>();
        ParentSlot = GetComponentInParent<Slot>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _parent = transform.parent;
        transform.parent = _mainCanvs.transform;
        transform.parent.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvs.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EndDrag();
    }

    public void EndDrag()
    {
        transform.SetParent(_parent);
        _rectTransform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ParentSlot.StorageItem.Use(ParentSlot);
    }
}