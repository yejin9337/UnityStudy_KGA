using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("�׷��� Ÿ�� ���")]
    [SerializeField] MeshRenderer meshRenderer = null;
    public MeshRenderer MeshRenderer => meshRenderer;

    /// <summary> �����ϱ��� ���� ��Ƽ���� </summary>
    public Material OriginalMaterial { get; set; }
    public Define.ETileType Type { get; set; } = Define.ETileType.None;
    
    /// <summary> ������ �ٲ��� </summary>
    public void Refresh()
    {
        meshRenderer.material = OriginalMaterial;
    }


}
