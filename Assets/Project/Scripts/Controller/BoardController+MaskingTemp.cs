using System.Collections.Generic;
using UnityEngine;

public partial class BoardController
{
    [SerializeField] GameObject maskObject;
    private float yoffset = 0.625f;
    private float wallOffset = 0.225f;
    private List<GameObject> quads = new List<GameObject>();

    private void CreateMaskingTemp()
    {
        foreach (var quad in quads)
        {
            Destroy(quad);
        }
        quads.Clear();

        float xValue = BoardWidth/2;
        float zValue = BoardHeight/2;
        GameObject quadObj = view.CreateQuad(new Vector3(xValue, yoffset, zValue));
        quadObj.transform.localScale = new Vector3(BoardWidth + wallOffset * 2, BoardHeight + wallOffset * 2, 1);
        quads.Add(quadObj);

        maskObject.SetActive(true);
    }
}