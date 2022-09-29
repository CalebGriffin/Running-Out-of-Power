using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private string position;
    public string Position {get {return position;} set {position = value;}}
    public bool isLast = false;


    [SerializeField] private int id;
    public int Id {get; private set;}
    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(0, 2f * Time.deltaTime, 0);
    }
    private void FixedUpdate() {
        rb.velocity = Vector2.down * speed * Time.deltaTime;
        
    }
}
