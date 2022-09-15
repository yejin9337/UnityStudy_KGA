using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    private bool isRightArrowKeyDown = false;
    private bool isLeftArrowKeyDown = false;
    private bool isMoving = false;
    private bool isRight = false;
    private bool isLeft = true;
    public GameObject A;
    public GameObject B;
    private float delay = 5.0f;

    private float elapsedTime;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) && isMoving == false && isLeft)
        {
            isRightArrowKeyDown = true;
            isMoving = true;
        }

        if (isRightArrowKeyDown)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > delay)
            {
                elapsedTime = 0;
                transform.position = Vector3.Lerp(A.transform.position, B.transform.position, 1f);
                isRightArrowKeyDown = false;
                isMoving = false;
                isLeft = false;
                isRight = true;
            }
            else
            transform.position = Vector3.Lerp(A.transform.position, B.transform.position, elapsedTime / delay);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && (isMoving == false) && isRight)
        {
            isLeftArrowKeyDown = true;
            isMoving = true;
        }


        if (isLeftArrowKeyDown)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 5.0)
            {
                elapsedTime = 0;
                transform.position = Vector3.Lerp(B.transform.position, A.transform.position, 1f);
                isLeftArrowKeyDown = false;
                isMoving =false;
                isLeft = true;
                isRight = false;
            }
            else
            transform.position = Vector3.Lerp(B.transform.position, A.transform.position, elapsedTime / delay);
        }
    }
}
