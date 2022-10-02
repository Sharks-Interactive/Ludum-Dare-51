using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/// <summary>
/// Implements drag events for UI
/// </summary>
public class DragBehaviour : UIBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected bool mouseOver = false;
    protected bool dragging = false;

    public void OnPointerEnter(PointerEventData eventData) => mouseOver = true;
    // Don't stop dragging if the user's mouse button is still down - their mouse can leave the window while dragging, but shouldn't stop clicking
    public void OnPointerExit(PointerEventData eventData) => mouseOver = false;

    void Update()
    {
        if (!(mouseOver || dragging)) return;

        if (Mouse.current.leftButton.wasPressedThisFrame) OnDragStart(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasReleasedThisFrame) OnDragEnd(Mouse.current.position.ReadValue());
        if (!(Mouse.current.leftButton.isPressed && dragging)) return;

        WhileDrag(Mouse.current.position.ReadValue());
    }

    protected virtual void OnDragStart(Vector3 MousePosition) => dragging = true;
    protected virtual void OnDragEnd(Vector3 MousePosition) => dragging = false;
    protected virtual void WhileDrag(Vector3 MousePosition) { }
}
