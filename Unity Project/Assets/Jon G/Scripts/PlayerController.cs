using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public partial class PlayerController : MonoBehaviour
{
    // Player Input Reference
        private PlayerInput Player()
        { return GetComponent<PlayerInput>(); }

    // Input Data
        private bool canGoLeft = false, canGoRight = false;
        private Coroutine leftRoutine, rightRoutine;

    // States
        [SerializeField] private uint powerLevel = 0;

        [System.Serializable]
        private enum CurrentAction { Run, Jump, Flip }
        [SerializeField] private CurrentAction currentAction;

    // Action Level Requirements
        private uint runCost = 0;
        private uint jumpCost = 3;
        private uint flipCost = 1;

    private void FixedUpdate()
    {
        Run_Extension();
    }
    
    private void OnLeft_Stick(InputValue value)
    {
        // Get the Vector2 from the input value
        Vector2 inputVector = value.Get<Vector2>();

        // Do something with the input here

        if (inputVector.x >= 0.5f)
        { 
            canGoRight = true;
            
            if (rightRoutine != null)
            { StopCoroutine(rightRoutine); }
            
            rightRoutine = StartCoroutine(ToggleRight());
        }
        else if (inputVector.x <= -0.5f)
        { 
            canGoLeft = true;

            if (leftRoutine != null)
            { StopCoroutine(leftRoutine); }
            
            leftRoutine = StartCoroutine(ToggleLeft());
        }
        else 
        {
            canGoRight = false; canGoLeft = false;
            return; 
        }

    }

    private void OnSouth_Button()
    {
        // This will run when the south button is pressed

        Debug.Log($"Executing {currentAction.ToString()} Action");

        Invoke("Action_" + currentAction.ToString(), 0f);
    }

}
