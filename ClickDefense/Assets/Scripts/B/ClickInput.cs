using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ClickInput : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameSignals.RaiseClicked();
    }
}