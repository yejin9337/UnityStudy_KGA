using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // 싱글톤 만들기
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

    [Header("타일 타입")]
    [SerializeField] Material matDefault;
    [SerializeField] Material matBush;
    [SerializeField] Material matWall;
    [SerializeField] Material matWater;

    [Header("미리보기 색상")]
    [SerializeField] Color colorPrev;

    [Header("타일 프리펩")]
    [SerializeField] Tile prefabTile;

    [Header("생성할 플레이어 프리펩")]
    [SerializeField] GameObject player;

    /// <summary> 맵 전체 타일의 배열 </summary>
    private List<Tile> tiles = new List<Tile>(Define.TileMaxCount);

    /// <summary>현재 선택한 타일의 타입</summary>
    private Define.ETileType curTileType = Define.ETileType.None;
    private Material curTypeMaterial = null;
    private int curTileIndex = 0;

    /// <summary>드래그 중인지 여부</summary>
    private bool isDrag = false;

    /// <summary>게임 실행시 맵의 크기만큼 타일 프리펩을 생성함</summary>
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
            //이거 무슨뜻?
            tiles[curTileIndex].Refresh();
            return;
        }

        int index = GetTileIndex(pos);

        //선택한 타일이 바뀐게 없다면
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
