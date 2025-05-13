using System.Collections.Generic;
using UnityEngine;

public class BoardModel 
{
    public int Width => width;
    public int Height => height;
    
    int width = 0;
    int height = 0;

    public void SetModel(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
}
