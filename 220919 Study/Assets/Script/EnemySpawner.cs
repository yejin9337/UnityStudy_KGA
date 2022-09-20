using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private int count = 5000;

    public Transform randomPos;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            randomPos.position = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
            Instantiate(enemy, randomPos.position, Quaternion.identity);
        }
    }


    void Update()
    {

    }
}