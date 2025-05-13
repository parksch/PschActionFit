using System.Collections.Generic;
using UnityEngine;

public partial class StageEditorManager : MonoBehaviour
{
    static public StageEditorManager Instance;

    [SerializeField] float groundOffset;
    [SerializeField] float wallOffset;

    [SerializeField] Transform groundParent;
    [SerializeField] Transform wallParent;

    [SerializeField] GameObject wallhPrefab;
    [SerializeField] GameObject wallvPrefab;
    [SerializeField] GameObject groundPrefab;

    [SerializeField] List<Material> colors;
    [SerializeField] List<GameObject> gridObjects;
    [SerializeField] List<GameObject> wallObjects;

    [SerializeField] ColorType currentColor;

    void Awake()
    {
        Instance = this;
        Init();
        InitUI();
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

        foreach (GameObject go in wallObjects)
        {
            Destroy(go);
        }
        wallObjects.Clear();

        int xMax = 0;
        int.TryParse(xInput.text, out xMax);
        int yMax = 0;
        int.TryParse(yInput.text, out yMax);

        for (int y = -1; y <= yMax; y++)
        {
            for (int x = -1; x <= xMax; x++)
            {

                if (y == -1)
                {
                    if (x != -1 && x != xMax)
                    {
                        GameObject wallh = Instantiate(wallhPrefab, wallParent);
                        wallh.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, (yMax / 2f) + wallOffset);
                        wallObjects.Add(wallh);
                    }
                }
                else if (y == yMax)
                {
                    if (x != -1 && x != xMax)
                    {
                        GameObject wallh = Instantiate(wallhPrefab, wallParent);
                        wallh.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, (yMax / 2f) - ((yMax - 1) * groundOffset) - wallOffset);
                        wallObjects.Add(wallh);
                    }
                }
                else
                {
                    if (x == -1)
                    {
                        if (y != -1 && y != yMax)
                        {
                            GameObject wallv = Instantiate(wallvPrefab, wallParent);
                            wallv.transform.position = new Vector3(-(xMax / 2f) - wallOffset,0, (yMax / 2f) - y * groundOffset);
                            wallObjects.Add(wallv);
                        }
                    }
                    else if(x == xMax)
                    {
                        if (y != -1 && y != yMax)
                        {
                            GameObject wallv = Instantiate(wallvPrefab, wallParent);
                            wallv.transform.position = new Vector3(-(xMax / 2f) + (xMax - 1) * groundOffset + wallOffset, 0, (yMax / 2f) - y * groundOffset);
                            wallObjects.Add(wallv);
                        }
                    }
                    else
                    {
                        GameObject ground = Instantiate(groundPrefab, groundParent);
                        ground.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, (yMax / 2f) - y * groundOffset);
                        gridObjects.Add(ground);
                    }
                }

            }
        }
    }

    public void LoadObjects(StageJsonData stageJson)
    {

    }
}

