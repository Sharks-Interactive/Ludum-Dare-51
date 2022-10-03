using SharkUtils;
using UnityEngine;
using static SharkUtils.ExtraFunctions;

public class Handle : DragBehaviour
{
    public Vector2 Bounds;
    protected Vector3 offset;

    protected override void OnDragStart(Vector3 MousePosition)
    {
        base.OnDragStart(MousePosition);
        offset = rectTransform.position - MousePosition;
    }

    protected override void WhileDrag(Vector3 MousePosition)
    {
        base.WhileDrag(MousePosition);

        rectTransform.position = transform.UpdateAxis(Mathf.Clamp(MousePosition.y + offset.y, Bounds.x, Screen.height * Bounds.y), Axis.Y);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            new Vector2(transform.position.x, Bounds.x),
            new Vector2(transform.position.x, Screen.height * Bounds.y)
        );
    }
#endif
}
