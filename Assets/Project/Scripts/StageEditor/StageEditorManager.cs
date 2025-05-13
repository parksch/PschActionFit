using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Data_Script;

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

    public List<Material> Colors => colors;
    public ColorType CurrentType => currentColor;

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
                        TileWall wallh = Instantiate(wallhPrefab, wallParent).GetComponent<TileWall>();
                        wallh.Set(x,y+1);
                        wallh.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, -(yMax / 2f) - wallOffset);
                        wallObjects.Add(wallh.gameObject);
                    }
                }
                else if (y == yMax)
                {
                    if (x != -1 && x != xMax)
                    {
                        TileWall wallh = Instantiate(wallhPrefab, wallParent).GetComponent<TileWall>();
                        wallh.Set(x, y - 1);
                        wallh.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, -(yMax / 2f) + ((yMax - 1) * groundOffset) + wallOffset);
                        wallObjects.Add(wallh.gameObject);
                    }
                }
                else
                {
                    if (x == -1)
                    {
                        if (y != -1 && y != yMax)
                        {
                            TileWall wallv = Instantiate(wallvPrefab, wallParent).GetComponent<TileWall>();
                            wallv.Set(x + 1, y);
                            wallv.transform.position = new Vector3(-(xMax / 2f) - wallOffset,0, -(yMax / 2f) + y * groundOffset);
                            wallObjects.Add(wallv.gameObject);
                        }
                    }
                    else if(x == xMax)
                    {
                        if (y != -1 && y != yMax)
                        {
                            TileWall wallv = Instantiate(wallvPrefab, wallParent).GetComponent<TileWall>();
                            wallv.Set(x - 1, y);
                            wallv.transform.position = new Vector3(-(xMax / 2f) + (xMax - 1) * groundOffset + wallOffset, 0, -(yMax / 2f) + y * groundOffset);
                            wallObjects.Add(wallv.gameObject);
                        }
                    }
                    else
                    {
                        TileGround ground = Instantiate(groundPrefab, groundParent).GetComponent<TileGround>();
                        ground.Set(x, y);
                        ground.transform.position = new Vector3(-(xMax / 2f) + x * groundOffset, 0, -(yMax / 2f) + y * groundOffset);
                        gridObjects.Add(ground.gameObject);
                    }
                }

            }
        }
    }

    public void LoadObjects(StageJsonData stageJson)
    {
        foreach (var item in gridObjects)
        {
            Destroy(item);
        }
        gridObjects.Clear();

        foreach (var item in wallObjects)
        {
            Destroy(item);
        }
        wallObjects.Clear();

        int xMax = 0;
        int.TryParse(xInput.text, out xMax);
        int yMax = 0;
        int.TryParse(yInput.text, out yMax);

        foreach (var item in stageJson.boardBlocks)
        {
            TileGround ground = Instantiate(groundPrefab, groundParent).GetComponent<TileGround>();
            ground.Set(item.x, item.y, item.colorType);
            ground.transform.position = new Vector3(-(xMax / 2f) + item.x * groundOffset, 0, -(yMax / 2f) + item.y * groundOffset);
            gridObjects.Add(ground.gameObject);
        }
    }
}

