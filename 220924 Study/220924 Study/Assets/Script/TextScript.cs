using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum playerState
{
    RIGHT,
    LEFT,
}
public class TextScript : MonoBehaviour
{
    public TextMeshProUGUI scriptText;
    private playerState state;
    void Start()
    {
        state = playerState.RIGHT;
    }

    void Update()
    {
        switch (state) {
            case playerState.RIGHT: scriptText.text = "�������� ���� �ִ�";
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "�������� ���� �����̰� �ִ�";
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    state = playerState.LEFT;
                }

                if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
                {
                    scriptText.text = "�������� ���� �޸��� �ִ�";
                }
                if(Input.GetKey(KeyCode.DownArrow))
                {
                    scriptText.text = "�������� �ٶ󺸸� ����� �ִ�";
                }
                if (Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "�������� ���� ���� �ִ�";
                }
                break;

            case playerState.LEFT:
                scriptText.text = "������ ���� �ִ�";
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    scriptText.text = "������ ���� �����̰� �ִ�";
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    state = playerState.RIGHT;
                }

                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
                {
                    scriptText.text = "������ ���� �޸��� �ִ�";
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    scriptText.text = "������ �ٶ󺸸� ����� �ִ�";
                }
                if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "������ ���� ���� �ִ�";
                }
                break;
        }
    }
}
