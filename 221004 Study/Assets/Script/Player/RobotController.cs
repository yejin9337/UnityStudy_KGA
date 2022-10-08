using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField]
    private GameObject robotA;
    [SerializeField]
    private GameObject robotB;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1¹ø·Îº¿");
            robotA.GetComponent<Robot>().CanMoving = true;
            robotB.GetComponent<Robot>().CanMoving = false;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2¹ø·Îº¿");
            robotA.GetComponent<Robot>().CanMoving = false;
            robotB.GetComponent<Robot>().CanMoving = true;
        }
    }
}
