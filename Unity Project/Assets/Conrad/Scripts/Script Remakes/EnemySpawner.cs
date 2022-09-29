using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int NoOfEnemies;
    private bool EnemyRequest;
    [SerializeField]
    private GameObject EnemyIns;
    private int ESpawn = 1;
    private GameObject[] spawnpoints = new GameObject[5];
    [SerializeField]
    private GameObject ObjectivePoint;
    private int Enemylimit = 2;



    private void FixedUpdate()
    {
        if (NoOfEnemies < Enemylimit)
        {
            EnemyRequest = true;
        }
        else
        {
            EnemyRequest = false;
        }
        switch (ESpawn)
        {
            case 1:
                ObjectivePoint = spawnpoints[0];
                break;
            case 2:
                ObjectivePoint = spawnpoints[1];
                break;
            case 3:
                ObjectivePoint = spawnpoints[2];
                break;
            case 4:
                ObjectivePoint = spawnpoints[3];
                break;
            case 5:
                ObjectivePoint = spawnpoints[4];
                break;
        }
    }

    private void Awake()
    {
        spawnpoints[0] = gameObject.transform.GetChild(0).gameObject;
        spawnpoints[1] = gameObject.transform.GetChild(1).gameObject;
        spawnpoints[2] = gameObject.transform.GetChild(2).gameObject;
        spawnpoints[3] = gameObject.transform.GetChild(3).gameObject;
        spawnpoints[4] = gameObject.transform.GetChild(4).gameObject;
        SpawnMore();
    }

    private void SpawnMore()
    {
        if (EnemyRequest == true)
        {
            GameObject enemy = Instantiate(EnemyIns, ObjectivePoint.transform.position, Quaternion.identity, ObjectivePoint.transform);
            if (ESpawn == 5)
            {
                ESpawn = 1;
            }
            else
            {
                ESpawn++;
            }
            NoOfEnemies += 1;
        }
        Invoke("SpawnMore", 2f);
    }
}
