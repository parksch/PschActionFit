using UnityEngine;

public partial class StageEditorManager : MonoBehaviour
{
    static public StageEditorManager Instance;

    void Awake()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        CreateGrid();
    }

    public void CreateGrid()
    {
        int xMax = 0;
        int.TryParse(xText.text, out xMax);
        int yMax = 0;
        int.TryParse(yText.text, out yMax);

        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {

            }
        }
    }

    public void OnClickCreateButton()
    {

    }
}

