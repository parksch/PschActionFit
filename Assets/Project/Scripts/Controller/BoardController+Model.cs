using UnityEngine;

public partial class BoardController
{
    public int BoardWidth => model.Width;
    public int BoardHeight => model.Height;

    BoardModel model;

    void InitializeModel()
    {
        model = new BoardModel();
    }

    void SetModel(int width,int height)
    {
        model.SetModel(width,height);
    }
}
