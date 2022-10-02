using Chrio.World;
using Chrio.World.Loading;
using UnityEngine;

/// <summary>
/// Base class for a draggable UI window that remains within bounds and brings itself to the front when being clicked
/// </summary>
public class DraggableWindow : DragBehaviour
{
    public RectTransform Bounds;
    protected Vector3 offset;

    public override void OnLoad(Game_State.State _gameState, ILoadableObject.CallBack _callback)
    {
        base.OnLoad(_gameState, _callback);

        Bounds = GameObject.FindGameObjectWithTag("Desktop").GetComponent<RectTransform>();
    }

    protected override void OnDragStart(Vector3 MousePosition)
    {
        base.OnDragStart(MousePosition);

        offset = rectTransform.position - MousePosition;
        rectTransform.SetAsLastSibling(); // Bring us to front
    }

    protected override void WhileDrag(Vector3 MousePosition)
    {
        base.WhileDrag(MousePosition);

        // Don't move us out of bounds
        if (!Bounds.rect.Contains(Bounds.InverseTransformPoint(MousePosition + offset))) return;
        rectTransform.position = MousePosition + offset;
        
    }
}
