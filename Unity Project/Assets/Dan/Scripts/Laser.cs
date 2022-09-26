using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, 0, 1);
        StartCoroutine(EnlargeLaser());
    }
    private IEnumerator EnlargeLaser(){
        while(transform.localScale.y < 1){
            Debug.Log("Enlarging");
            transform.localScale = new Vector3(1, transform.localScale.y + 0.05f, 1);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * 3f * Time.deltaTime;
    }
}
