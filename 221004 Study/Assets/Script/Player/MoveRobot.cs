//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveRobot : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject robotA;
//    [SerializeField]
//    private GameObject robotB;
//    [SerializeField]
//    private float moveSpeed = 2;

//    private Vector3 curDir;
//    private Vector3 curRobotPos;

//    void Start()
//    {
//        curDir = Vector3.zero;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            Debug.Log("1¹ø µé¾î¿È");
//            curRobotPos = robotA.transform.position;
//        }
//        if (Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            curRobotPos = robotB.transform.position;
//        }
//        Move(curRobotPos);
//    }

//    private void Move(Vector3 curRobotPos)
//    {

//        curDir = Vector3.zero;

//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
//            Debug.Log("LeftArrow");
//            curDir.x = -1;
//        }
//        else if (Input.GetKey(KeyCode.RightArrow))
//        {
//            curDir.x = 1;
//        }

//        if (Input.GetKey(KeyCode.UpArrow))
//        {
//            curDir.z = 1;
//        }
//        else if (Input.GetKey(KeyCode.DownArrow))
//        {
//            curDir.z = -1;
//        }

//        curRobotPos.Normalize();
//        curRobotPos += curDir * (moveSpeed * Time.deltaTime);
//    }
//}
