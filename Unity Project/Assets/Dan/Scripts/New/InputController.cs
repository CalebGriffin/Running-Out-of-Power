using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public Transform redbox;
    public Transform bluebox;
    private Container container1;
    private Container container2;
    private Container activeContainer;
    private void Start() {
        //Left: -6.45, Right: -4.55
        container1 = new Container(-6.45f, -4.55f, bluebox, redbox);
        container2 = new Container(4.5f, 6.45f, bluebox, redbox);
        activeContainer = container1;
    }

    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here
        activeContainer = inputVector.x < 0 ? container1 : container2;
        transform.position = new Vector3(inputVector.x < 0 ? -5.5f : 5.5f, 0, 0);
    }

    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
        Debug.Log("Running");
        
        activeContainer.SwitchBlocks();
        //float tempX = redbox.position.x;
        //redbox.position = new Vector3(bluebox.position.x, redbox.position.y, 0);
        //bluebox.position = new Vector3(tempX, bluebox.position.y, 0);
    }
}
