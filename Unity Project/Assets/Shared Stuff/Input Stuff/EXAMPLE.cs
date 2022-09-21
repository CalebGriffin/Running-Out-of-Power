using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// MUST ADD THIS LINE
using UnityEngine.InputSystem;

public class EXAMPLE : MonoBehaviour
{
    // ------------------------------------------------------------
    // READ THIS:
    // 1. Add the Player Input Component to the Game Object you want input on
    // 2. Add the "Main Input" input actions asset to the Player Input Component
    // 3. Make sure that the "Behaviour" is set to "Send Messages"
    // 4. Create a new C# Script on that GameObject
    // 5. Copy and paste the relevant methods from this script to that one
    // ------------------------------------------------------------

    // Gives an argument for a Vector2 for the direction in which the joystick is being pressed
    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here
    }

    // Gives an argument for a Vector2 for the direction in which the joystick is being pressed
    private void OnRight_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here
    }

    private void OnNorth_Button()
    {
        // This will run when the north button is pressed
    }

    private void OnEast_Button()
    {
        // This will run when the east button is pressed
    }

    private void OnSouth_Button()
    {
        // This will run when the south button is pressed
    }

    private void OnWest_Button()
    {
        // This will run when the west button is pressed
    }

    private void OnLeft_Bumper()
    {
        // This will run when the left bumper is pressed
    }

    private void OnRight_Bumper()
    {
        // This will run when the right bumper is pressed
    }

    private void OnLeft_Trigger()
    {
        // This will run when the left trigger is pressed
    }

    private void OnRight_Trigger()
    {
        // This will run when the right trigger is pressed
    }
}
