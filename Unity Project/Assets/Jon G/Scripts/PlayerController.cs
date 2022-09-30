using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public partial class PlayerController : MonoBehaviour
{

    /* Player Input Reference */
        private PlayerInput Player()
    { return GetComponent<PlayerInput>(); }

    /* Player Component References */
        private Rigidbody2D RigidBody()
    { return GetComponent<Rigidbody2D>(); }
        private SpriteRenderer Sprite()
    { return GetComponentInChildren<SpriteRenderer>(); }

    /* Enumerations*/
        [System.Serializable] private enum CurrentAction { Run, Jump, Flip }

    /* Variables */ [Header("Variables")]
        [SerializeField] private float moveSpeed = 450f;
        [SerializeField] private float jumpForce = 15f;
        [SerializeField] private float southButtonSampleRate = 0.25f;
        [SerializeField] private Color baseColour = new Color(1, 1, 1, 1), runColour = new Color(0, 1, 0, 1), jumpColour = new Color(0, 0, 1, 1), flipColour = new Color(1, 0, 0, 1);

    /* Attributes */
        private float MoveSpeed()
    { return Mathf.Abs(moveSpeed) * 2f * RigidBody().mass * Time.fixedDeltaTime; }
        private float Direction()
    { return !(flipped) ? 1f : -1f; }

    /* Input Data */
        private bool canGoLeft = false, canGoRight = false, mustReset = false;
        private Coroutine leftRoutine, rightRoutine;
        private float timeToAct = 0f;
        private bool CanAct()
    { return Time.time >= timeToAct + southButtonSampleRate; }
        private Color CurrentColour()
    { switch(currentAction) { case CurrentAction.Run: return runColour; case CurrentAction.Jump: return jumpColour; case CurrentAction.Flip: return flipColour; default: return baseColour;  } }

    /* States */
        private bool running = false;
        private bool flipped = false;
        [HideInInspector] public uint powerLevel = 0;
        private CurrentAction currentAction;

    /* Action Level Requirements */
        private uint runCost = 0;
        private uint jumpCost = 3;
        private uint flipCost = 1;

    private void Start()
    {
        ChangeColour(CurrentColour());
    }

    private void FixedUpdate()
    {
        Run_Extension();
    }
    
    private void OnLeft_Stick(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();

        if (mustReset) { return; }

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
        if (!(CanAct())) { return; }

        if (currentAction == CurrentAction.Run)
        { Action_Run(); }
        if (currentAction == CurrentAction.Jump)
        { Action_Jump(true); }
        if (currentAction == CurrentAction.Flip)
        { Action_Flip(true); }

        timeToAct = Time.time;
    }
}
