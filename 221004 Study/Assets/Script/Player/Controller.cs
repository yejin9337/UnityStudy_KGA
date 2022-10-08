//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Controller : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject robotA;
//    [SerializeField]
//    private GameObject robotB;
//    [SerializeField]
//    private float moveSpeed = 2;

//    private Vector3 curDir;

//    private bool moveA = false;

//    void Start()
//    {
//        curDir = Vector3.zero;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {         
//            moveA = true;
//        }
//        else if (Input.GetKeyDown(KeyCode.Alpha2))
//        {
//            moveA = false;
//        }

//        if(moveA)
//        {
//            curDir = Vector3.zero;

//            if (Input.GetKey(KeyCode.LeftArrow))
//            {
//                Debug.Log("LeftArrow");
//                curDir.x = -1;
//            }
//            else if (Input.GetKey(KeyCode.RightArrow))
//            {
//                curDir.x = 1;
//            }

//            if (Input.GetKey(KeyCode.UpArrow))
//            {
//                curDir.z = 1;
//            }
//            else if (Input.GetKey(KeyCode.DownArrow))
//            {
//                curDir.z = -1;
//            }

//            curDir.Normalize();
//            robotA.transform.position += curDir * (moveSpeed * Time.deltaTime);
//        }

//        else
//        {
//            curDir = Vector3.zero;

//            if (Input.GetKey(KeyCode.LeftArrow))
//            {
//                Debug.Log("LeftArrow");
//                curDir.x = -1;
//            }
//            else if (Input.GetKey(KeyCode.RightArrow))
//            {
//                curDir.x = 1;
//            }

//            if (Input.GetKey(KeyCode.UpArrow))
//            {
//                curDir.z = 1;
//            }
//            else if (Input.GetKey(KeyCode.DownArrow))
//            {
//                curDir.z = -1;
//            }

//            curDir.Normalize();
//            robotB.transform.position += curDir * (moveSpeed * Time.deltaTime);
//        }

//    }
//}
