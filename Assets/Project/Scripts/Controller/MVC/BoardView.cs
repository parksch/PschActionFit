using Project.Scripts.Data_Script;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.Rendering.ProbeAdjustmentVolume;

public class BoardView : MonoBehaviour
{
    [SerializeField] private GameObject quadPrefab;
    [SerializeField] private GameObject boardBlockPrefab;
    [SerializeField] private GameObject blockGroupPrefab;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private Material[] blockMaterials;
    [SerializeField] private Material[] testBlockMaterials;
    [SerializeField] private GameObject[] wallPrefabs;
    [SerializeField] private Material[] wallMaterials;
    [SerializeField] private Transform spawnerTr;
    [SerializeField] private Transform quadTr;
    [SerializeField] ParticleSystem destroyParticle;

    private GameObject boardParent;
    private GameObject playingBlockParent;
    private readonly float blockDistance = 0.79f;

    public GameObject BoardParent => boardParent;
    public GameObject PlayingBlockParent => playingBlockParent;
    public Material[] WallMaterials => wallMaterials;
    public ParticleSystem DestroyParticle => destroyParticle;

    public void Init()
    {
        boardParent = new GameObject("BoardParent");
        boardParent.transform.SetParent(transform);
        playingBlockParent = new GameObject("PlayingBlockParent");
    }

    public void CreateCustomWalls()
    {

    }

    public BoardBlockObject CreateBoardBlock(int x,int y,BoardController controller)
    {
        GameObject blockObj = Instantiate(boardBlockPrefab, boardParent.transform);
        blockObj.transform.localPosition = new Vector3(
            x * blockDistance,
            0,
            y * blockDistance
        );

        if (blockObj.TryGetComponent(out BoardBlockObject boardBlock))
        {
            boardBlock._ctrl = controller;
            boardBlock.x = x;
            boardBlock.y = y;
            return boardBlock;
        }
        else
        {
            return null;
        }
    }

    public GameObject CreateGroupObject(int x,int y)
    {
        GameObject blockGroupObject = Instantiate(blockGroupPrefab, playingBlockParent.transform);
        blockGroupObject.transform.position = new Vector3(
            x * blockDistance,
            0.33f,
            y * blockDistance
        );

        return blockGroupObject;
    }

    public BlockObject CreateBlock(GameObject blockGroupObject, int x,int y,Vector2 center,ColorType colorType)
    {
        GameObject singleBlock = Instantiate(blockPrefab, blockGroupObject.transform);

        singleBlock.transform.localPosition = new Vector3(
        center.x * blockDistance,
            0f,
        center.y * blockDistance
        );

        var renderer = singleBlock.GetComponentInChildren<SkinnedMeshRenderer>();
        if (renderer != null && colorType >= 0)
        {
            renderer.material = testBlockMaterials[(int)colorType];
        }

        if (singleBlock.TryGetComponent(out BlockObject blockObj))
        {
            blockObj.colorType = colorType;
            blockObj.x = x;
            blockObj.y = y;
            blockObj.offsetToCenter = center;
            return blockObj;
        }
        else
        {
            return null;
        }
    }

    public WallObject CreateWall(int index,ColorType colorType, Vector3 position, Quaternion rotation,Transform parent)
    {
        if (index < 0 && index >= wallPrefabs.Length)
        {
            Debug.LogError($"프리팹 인덱스 범위를 벗어남: {index}, 사용 가능한 프리팹: 0-{wallPrefabs.Length}");
            return null;
        }

        GameObject wallObj = Instantiate(wallPrefabs[index], parent);
        wallObj.transform.position = position;
        wallObj.transform.rotation = rotation;
        WallObject wall = wallObj.GetComponent<WallObject>();
        wall.SetWall(wallMaterials[(int)colorType], colorType != ColorType.None);

        return wall;
    }

    public GameObject CreateQuad(Vector3 pos)
    {
        GameObject quad = Instantiate(quadPrefab, quadTr);
        quad.transform.position = blockDistance * pos;
        return quad;
    }

}
