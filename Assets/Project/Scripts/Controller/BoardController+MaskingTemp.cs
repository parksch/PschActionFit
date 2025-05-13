using System.Collections.Generic;
using UnityEngine;

public partial class BoardController
{
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
        
        for (int i = -3; i <= BoardWidth + 3; i++)
        {
            for (int j = -3; j <= BoardHeight + 3; j++)
            {
                if (boardBlockDic.ContainsKey((i, j))) continue;

                float xValue = i;
                float zValue = j;
                if (i == -1 && j <= BoardHeight) xValue -= wallOffset;
                if (i == BoardWidth + 1 && j <= BoardHeight + 1) xValue += wallOffset;
                
                if (j == -1 && i <= BoardWidth) zValue -= wallOffset;
                if (j == BoardHeight + 1 && i <= BoardWidth + 1) zValue += wallOffset;
                
                GameObject quad = view.CreateQuad(new Vector3(xValue, yoffset, zValue));
                quads.Add(quad);                
            }
        }
    }
}