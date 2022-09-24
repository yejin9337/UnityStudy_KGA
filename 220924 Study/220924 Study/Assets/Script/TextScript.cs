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
            case playerState.RIGHT: scriptText.text = "오른쪽을 보고 있다";
                if(Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "오른쪽을 향해 움직이고 있다";
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    state = playerState.LEFT;
                }

                if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
                {
                    scriptText.text = "오른쪽을 향해 달리고 있다";
                }
                if(Input.GetKey(KeyCode.DownArrow))
                {
                    scriptText.text = "오른쪽을 바라보며 엎드려 있다";
                }
                if (Input.GetKey(KeyCode.DownArrow)&& Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "오른쪽을 향해 기어가고 있다";
                }
                break;

            case playerState.LEFT:
                scriptText.text = "왼쪽을 보고 있다";
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    scriptText.text = "왼쪽을 향해 움직이고 있다";
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    state = playerState.RIGHT;
                }

                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
                {
                    scriptText.text = "왼쪽을 향해 달리고 있다";
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    scriptText.text = "왼쪽을 바라보며 엎드려 있다";
                }
                if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    scriptText.text = "왼쪽을 향해 기어가고 있다";
                }
                break;
        }
    }
}
