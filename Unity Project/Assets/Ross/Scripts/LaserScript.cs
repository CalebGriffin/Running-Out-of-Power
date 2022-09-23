using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Do a simple fade out animation.
        transform.localScale = new Vector3(transform.localScale.x - (Time.deltaTime * 3.0f), 1.0f, 1.0f);
        if (transform.localScale.x <= 0.0f)
            Destroy(gameObject);

    }
}
