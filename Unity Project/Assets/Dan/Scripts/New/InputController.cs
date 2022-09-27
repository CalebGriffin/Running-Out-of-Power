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
    public Container ActiveContainer {get {return activeContainer;} private set {activeContainer = value;}}
    private void Start() {
        //Left: -6.45, Right: -4.55
        container1 = new Container(-4.55f, -6.45f, -4.55f, bluebox, redbox);
        container2 = new Container(4.5f, 4.5f, 6.45f, bluebox, redbox);
        activeContainer = container1;
    }

    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here
        activeContainer = inputVector.x < 0 ? container1 : container2;
        transform.position = new Vector3(inputVector.x < 0 ? -5.5f : 5.5f, -1, 0);
    }

    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
        
        
        activeContainer.SwitchBlocks();
    }
}
