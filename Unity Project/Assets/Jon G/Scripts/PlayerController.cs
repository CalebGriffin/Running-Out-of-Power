using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public partial class PlayerController : MonoBehaviour
{

    /* Player Input Reference */
        private PlayerInput Player() { return GetComponent<PlayerInput>(); }

    /* Player Component References */
        private Rigidbody2D RigidBody() { return GetComponent<Rigidbody2D>(); }

    /* Enumerations*/
        [System.Serializable] private enum CurrentAction { Run, Jump, Flip }

    /* Variables */ [Header("Variables")]
        [SerializeField] private float moveSpeed = 450f;
        [SerializeField] private float jumpForce = 15f;

    /* Attributes */
        private float MoveSpeed() { return Mathf.Abs(moveSpeed) * Time.fixedDeltaTime; }
        private float Direction() { return !(flipped) ? 1f : -1f; }

    /* Input Data */
        private bool canGoLeft = false, canGoRight = false;
        private Coroutine leftRoutine, rightRoutine;

    /* States */
        private bool running = false;
        private bool flipped = false;
        private uint powerLevel = 0;
        private CurrentAction currentAction;

    /* Action Level Requirements */
        private uint runCost = 0;
        private uint jumpCost = 3;
        private uint flipCost = 1;

    private void FixedUpdate()
    {
        Run_Extension();
    }
    
    private void OnLeft_Stick(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();

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
        Invoke("Action_" + currentAction.ToString(), 0f);
    }
}
