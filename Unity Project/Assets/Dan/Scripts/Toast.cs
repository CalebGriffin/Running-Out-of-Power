using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    public void StartUp(Vector3 target){
        direction = target - rb.transform.position;

        //Ensure the toast is always rotated to face the player 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void FixedUpdate() {
        rb.velocity = direction * speed;
    }
}
