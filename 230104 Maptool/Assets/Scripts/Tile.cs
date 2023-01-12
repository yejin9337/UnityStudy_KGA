using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("그려질 타일 모양")]
    [SerializeField] MeshRenderer meshRenderer = null;
    public MeshRenderer MeshRenderer => meshRenderer;

    /// <summary> 변경하기전 기존 머티리얼 </summary>
    public Material OriginalMaterial { get; set; }
    public Define.ETileType Type { get; set; } = Define.ETileType.None;
    
    /// <summary> 색상을 바꿔줌 </summary>
    public void Refresh()
    {
        meshRenderer.material = OriginalMaterial;
    }


}
