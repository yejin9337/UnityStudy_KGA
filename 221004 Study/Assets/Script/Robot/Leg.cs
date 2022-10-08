//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Leg : MonoBehaviour
//{
//    private Vector3 curDir;

//    private Body body;

//    public bool IsMoving { get; set; }

//    private void Awake()
//    {
//        curDir = Vector3.zero;
//    }

//    void Update()
//    {
//        if (IsMoving == false)
//        {
//            return;
//        }

//        Move();
//    }
//    private void Move()
//    {

//        curDir = Vector3.zero;

//        if (Input.GetKey(KeyCode.LeftArrow))
//        {
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

//        curDir.Normalize();

//        transform.position += curDir * (body.speed * Time.deltaTime);
//    }
//}
