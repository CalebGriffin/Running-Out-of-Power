using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCore : MonoBehaviour
{
    public float maxTime = 2f;
    float timer;
    public GameObject Core;
    public float speed = 20;
    public float y;
    GameObject newcore;

    // Update is called once per frame
    void Update()
    {
        Vector2 random = new Vector2(Random.Range(-4f, -7f), y);

        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            GameObject newcore = Instantiate(Core, random, transform.rotation);
            timer = 0;
            Destroy(newcore, 10f);
        }
        Destroy(newcore, 12f);
    }
}
