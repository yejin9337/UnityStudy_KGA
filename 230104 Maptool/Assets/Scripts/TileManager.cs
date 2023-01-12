using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // �̱��� �����
    private static TileManager _instance = null;
    static TileManager()
    {

    }
    public static TileManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<TileManager>();
            }
            return _instance;
        }
    }

    [Header("Ÿ�� Ÿ��")]
    [SerializeField] Material matDefault;
    [SerializeField] Material matBush;
    [SerializeField] Material matWall;
    [SerializeField] Material matWater;

    [Header("�̸����� ����")]
    [SerializeField] Color colorPrev;

    [Header("Ÿ�� ������")]
    [SerializeField] Tile prefabTile;

    [Header("������ �÷��̾� ������")]
    [SerializeField] GameObject player;

    /// <summary> �� ��ü Ÿ���� �迭 </summary>
    private List<Tile> tiles = new List<Tile>(Define.TileMaxCount);

    /// <summary>���� ������ Ÿ���� Ÿ��</summary>
    private Define.ETileType curTileType = Define.ETileType.None;
    private Material curTypeMaterial = null;
    private int curTileIndex = 0;

    /// <summary>�巡�� ������ ����</summary>
    private bool isDrag = false;

    /// <summary>���� ����� ���� ũ�⸸ŭ Ÿ�� �������� ������</summary>
    private void Start()
    {
        for(int i = 0; i < Define.TileMaxCount; i++)
        {
            var tile = Instantiate(prefabTile);
            tiles.Add(tile);
            tile.transform.position = new Vector3(i % Define.TileWidthCount, 0, i / Define.TileWidthCount);
            tile.OriginalMaterial = matDefault;
            tile.Refresh();
        }

        Init();
    }

    private void Init()
    {
        isDrag = false;
        curTileType = Define.ETileType.None;
        ChangePreviewColor(matDefault);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curTileType = Define.ETileType.None;
            ChangePreviewColor(matDefault);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curTileType = Define.ETileType.Bush;
            ChangePreviewColor(matBush);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            curTileType = Define.ETileType.Water;
            ChangePreviewColor(matWater);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            curTileType = Define.ETileType.Wall;
            ChangePreviewColor(matWall);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            player.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }

        CheckPreview();
    }

    private void ChangePreviewColor(Material mat)
    {
        curTypeMaterial = mat;
        colorPrev = mat.color;
        colorPrev.a = 0.5f;
        tiles[curTileIndex].Refresh();
    }

    private void CheckPreview()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * Define.CameraHeight);

        if (pos.x + Define.TileHalfSize < 0 || pos.z + Define.TileHalfSize < 0
            || pos.x + Define.TileHalfSize > Define.TileSize * Define.TileWidthCount
            || pos.z + Define.TileHalfSize > Define.TileSize * Define.TileHeightCount)
        {
            //�̰� ������?
            tiles[curTileIndex].Refresh();
            return;
        }

        int index = GetTileIndex(pos);

        //������ Ÿ���� �ٲ�� ���ٸ�
        if(index == curTileIndex) return;
        
        tiles[curTileIndex].Refresh();
        curTileIndex = index;
        var curTile = tiles[curTileIndex];
        curTile.MeshRenderer.material.color = colorPrev;

        if(isDrag)
        { 
            curTile.Type = curTileType;
            curTile.OriginalMaterial = curTypeMaterial;
            curTile.Refresh();
        }
    }

    public Define.ETileType GetTileType(Vector3 pos)
    {
        return GetTile(pos)?.Type ?? Define.ETileType.None;
    }

    private Tile GetTile(int index)
    {
        if (index < 0 || index > Define.TileMaxCount)
            return null;
        return tiles[index];
    }
    private Tile GetTile(Vector3 pos)
    {
        return GetTile(GetTileIndex(pos));
    }
    private int GetTileIndex(Vector3 pos)
    {
        int x = (int)(pos.x / Define.TileSize + Define.TileHalfSize);
        int y = (int)(pos.z / Define.TileSize + Define.TileHalfSize);
        int index = x + y * Define.TileWidthCount;

        return index;
    }
}
