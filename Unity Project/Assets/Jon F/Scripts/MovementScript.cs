using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpAmount = 7;

    public float distanceToCheck = 0.5f;
    public bool isGrounded;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
