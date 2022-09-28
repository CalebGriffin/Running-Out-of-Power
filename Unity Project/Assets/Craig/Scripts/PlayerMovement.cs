using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpForce = 1.0f;
    [SerializeField] private float playerGravity = -0.1f;
    [SerializeField] private float groundedDurationThreshold = 0.1f;
    [SerializeField] private float groundedVelocityThreshold = 0.01f;
    [SerializeField] private int maxInAirJumps = 2;



    [SerializeField] private float stickDeadbandThreshold = 0.3f;

    private bool leftPressed = false;
    private bool rightPressed = false;
    private bool southPressed = false;
    private bool touchingLevelLoader = false;

    private float groundedTimer = 0.0f;
    [SerializeField] private bool grounded = false;

    private int jumpCount = 0;


    private Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!grounded)
        {
            if(Mathf.Abs(myRB.velocity.y) <= groundedVelocityThreshold)
            {
                groundedTimer += Time.deltaTime;
            }
            else
            {
                groundedTimer = 0;
            }

            if (groundedTimer >= groundedDurationThreshold)
            {
                grounded = true;
                jumpCount = 0;
                groundedTimer = 0;
            }
        }
        else
        {
            if(Mathf.Abs(myRB.velocity.y) > groundedVelocityThreshold)
            {
                grounded = false;
                groundedTimer = 0;
            }
        }

        if(leftPressed)
        {
            gameObject.transform.position += (Vector3.left * speed * Time.deltaTime);
        }
        if (rightPressed)
        {
            gameObject.transform.position += (Vector3.right * speed * Time.deltaTime);
        }
        if (southPressed)
        {
            myRB.velocity = Vector2.Scale(myRB.velocity, new Vector2(1,0));
            myRB.AddForce(Vector2.up * jumpForce);
            
            southPressed = false;
        }

        gameObject.transform.position -= (Vector3.down * playerGravity);
    }

    private bool checkOutsideDeadband(float axis, float deadbandThreshold)
    {
        return (Mathf.Abs(axis) >= deadbandThreshold ? true : false);
    }

    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();
        Debug.Log("Left Stick: " + inputVector.ToString());
        if(checkOutsideDeadband(inputVector.x, stickDeadbandThreshold))
        {
            if(inputVector.x < 0)
            {
                leftPressed = true;
            }
            else
            {
                rightPressed = true;
            }
        }
        else
        {
            leftPressed = false;
            rightPressed = false;
        }

    }

    // Gives an argument for a Vector2 for the direction in which the joystick is being pressed
    private void OnRight_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();
        Debug.Log("Right Stick: " + inputVector.ToString());
        // Do something with the input here
    }

    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
        Debug.Log("South Button Pressed");

        if(touchingLevelLoader)
        {
            Debug.Log("Load Next Level");
            return;
        }

        if((southPressed == false) & (jumpCount < maxInAirJumps))
        {
            jumpCount++;
            southPressed = true;
        }

        
    }

    private void OnEast_Button()
    {
        // This will run when the east button is pressed
        //CubeController.Instance.RotateNext();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LevelLoader")
        {
            touchingLevelLoader = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "LevelLoader")
        {
            touchingLevelLoader = false;
        }
    }
}
