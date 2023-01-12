using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum ETileType
    {
        None,
        Bush,
        Wall,
        Water,
    }

    public const int TileWidthCount = 20;
    public const int TileHeightCount = 20;
    public const int TileMaxCount = TileWidthCount * TileHeightCount;
    public const float TileSize = 1.0f;
    public const float TileHalfSize = TileSize * 0.5f;

    public const float CameraHeight = 20.0f;
}
