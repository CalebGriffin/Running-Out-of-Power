using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float maxTime = 2f;
    float timer;
    public GameObject[] Enemy;
    public float speed = 20;
    public float y;
    GameObject newenemy;

    // Update is called once per frame
    void Update()
    {
        Vector2 random = new Vector2(Random.Range(-4f, -7f), y);

        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            GameObject newenemy = Instantiate(Enemy[Random.Range(0, Enemy.Length)], random, transform.rotation);
            timer = 0;
            Destroy(newenemy, 12f);
        }
        Destroy(newenemy, 10f);
    }
}
