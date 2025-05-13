using System.Collections.Generic;
using UnityEngine;

public partial class StageEditorManager : MonoBehaviour
{
    static public StageEditorManager Instance;
    [SerializeField] float groundOffset;

    [SerializeField] Transform groundParent;

    [SerializeField] GameObject groundPrefab;
    [SerializeField] List<GameObject> gridObjects;

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
        foreach (GameObject go in gridObjects)
        {
            Destroy(go);
        }
        gridObjects.Clear();

        int xMax = 0;
        int.TryParse(xText.text, out xMax);
        int yMax = 0;
        int.TryParse(yText.text, out yMax);

        for (int y = 0; y < yMax; y++)
        {
            for (int x = 0; x < xMax; x++)
            {
                GameObject ground = Instantiate(groundPrefab, groundParent);
                ground.transform.position = new Vector3(-(xMax/2f) + x * groundOffset, 0, (yMax / 2f) - y * groundOffset);
                gridObjects.Add(ground);
            }
        }
    }

    public void OnClickCreateButton()
    {
        CreateGrid();
    }
}

