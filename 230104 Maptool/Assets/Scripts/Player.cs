using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("�÷��̾� ����")]
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float oriSpeed = 10.0f;
    private float curSpeed = 0.0f;
    private float halfSpeed = 0.0f;

    // �� �浹�� ���� ��ġ�� ������Ű�� ����
    private Vector3 prevPosition = Vector3.zero;

    Define.ETileType curTileType;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        curTileType = Define.ETileType.None;
        curSpeed = oriSpeed;
        halfSpeed = oriSpeed * 0.5f;
        prevPosition = transform.position;
    }

    /// <summary> �÷��̾ �������� �� ����ִ� Ÿ��Ÿ���� �˾ƾ��� </summary>
    private void OnEnable()
    {
        curTileType = TileManager.Instance.GetTileType(transform.position);
        ChangeState(curTileType);
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        prevPosition = transform.position;
        transform.position += new Vector3(h, 0, v) * (curSpeed * Time.deltaTime);
        ChangeState(TileManager.Instance.GetTileType(transform.position));
    }

    private void ChangeState(Define.ETileType afterType)
    {
        Debug.Log(afterType);
        if (afterType == curTileType) return;

        // ���� Ÿ���� ���¿��� Ż��
        switch(curTileType)
        {
            case Define.ETileType.None:
                break;
            case Define.ETileType.Bush:
                ChangeAlpah();
                break;
            case Define.ETileType.Water:
                curSpeed = oriSpeed;
                break;
            case Define.ETileType.Wall:
                break;
            default:
                break;
        }
        
        curTileType = afterType;

        // �ٲ� Ÿ���� ���·� ����
        switch(afterType)
        {
            case Define.ETileType.None:
                break;
            case Define.ETileType.Bush:
                ChangeAlpah(0.5f);
                break;
            case Define.ETileType.Water:
                curSpeed = halfSpeed;
                break;
            case Define.ETileType.Wall:
                transform.position = prevPosition;
                ChangeState(TileManager.Instance.GetTileType(prevPosition));
                break;
            default:
                break;
        }

    }

    /// <summary>Color�� ���İ� ����</summary>
    /// <param name="value"> 0~1f ������ ���� �� ����. �⺻�� 1f</param>
    private void ChangeAlpah(float value = 1f)
    {
        Color color = meshRenderer.material.color;
        color.a = value;
        meshRenderer.material.color = color;
    }
}
