using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField] SpriteRenderer myRenderer;
    [SerializeField] Vector2Int vector;
    [SerializeField] ColorType color;

    public virtual void Set(int x,int y)
    {
        color = ColorType.None;
        vector.x = x;
        vector.y = y;
        myRenderer.material = StageEditorManager.Instance.Colors[(int)color];
    }

    public virtual void Set(int x, int y,ColorType colorType)
    {
        color = colorType;
        vector.x = x;
        vector.y = y;
        myRenderer.material = StageEditorManager.Instance.Colors[(int)color];
    }

    public virtual void ClickFun()
    {
        color = StageEditorManager.Instance.CurrentType;
        myRenderer.material = StageEditorManager.Instance.Colors[(int)color];
    }

    void OnMouseDown()
    {
        ClickFun();
    }
}
