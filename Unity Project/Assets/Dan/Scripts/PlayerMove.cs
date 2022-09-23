using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    private Animator anim;
    private GameObject attackObj;

    [Header("Values")]
    [SerializeField] private float speed;
    
    private void Awake() {
        //Get the first child 
        attackObj = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
    }
    private void Start() {
        attackObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here
        inputVector.y = 0;
        Debug.Log("Detecting Controller");
        rb.velocity = inputVector * speed;

        //Control the rotation of the robot
        if(inputVector.x < 0) transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        else if (inputVector.x > 0) transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        //Control the movement animation
        if(inputVector.x != 0) SetAnimationState(true);
        else SetAnimationState(false);
    }

    //Attack button
    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
        Debug.Log("Running");
        attackObj.SetActive(true);
    }
    private void SetAnimationState(bool condition) => anim.SetBool("isMoving", condition);
}
