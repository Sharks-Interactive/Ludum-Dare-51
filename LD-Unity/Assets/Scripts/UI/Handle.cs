using SharkUtils;
using UnityEngine;
using static SharkUtils.ExtraFunctions;

public class Handle : DragBehaviour
{
    public Vector2 Bounds;

    protected override void WhileDrag(Vector3 MousePosition)
    {
        base.WhileDrag(MousePosition);

        rectTransform.position = transform.UpdateAxis(Mathf.Clamp(MousePosition.y, Bounds.x, Bounds.y), Axis.Y);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            new Vector2(transform.position.x, Bounds.x),
            new Vector2(transform.position.x, Bounds.y)
        );
    }
#endif
}
