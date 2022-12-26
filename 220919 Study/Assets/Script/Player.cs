using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    private Transform _enemy;



    void Awake()
    {
       
    }
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(xInput, 0, zInput) * speed * Time.deltaTime;

        float dist = Vector3.Distance(_enemy.position, transform.position);
        //if()
        //{
        //    
        //}
    }
}
