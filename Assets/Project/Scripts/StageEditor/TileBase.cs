using UnityEngine;

public class TileBase : MonoBehaviour
{
    [SerializeField] SpriteRenderer myRenderer;
    [SerializeField] Vector2Int vector;

    public void Set(int x,int y)
    {

    }

    public virtual void ClickFun()
    {

    }

    void OnMouseDown()
    {
        ClickFun();
    }
}
