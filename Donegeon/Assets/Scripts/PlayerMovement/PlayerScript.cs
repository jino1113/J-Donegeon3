using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Rigidbody Rb;
    public GameObject CamHolder;
    public float Sensitivity;
    public Animator Animator;

    [Header("Movement")]

    public Vector2 m_Move, m_Look;
    private OnButtonInput m_Run;
    private float m_LookRotation;

    //---- New input ----//
    public PlayerInput playerInput;
    private CharacterController controller;
 
    // GPT
    public InputActionReference movementAction;
    public InputActionReference jumpAction;
    public InputActionReference runAction; // New InputAction for the run button

    public float moveSpeed = 5f;
    public float runMultiplier = 1.5f; // Speed multiplier when running
    public float jumpForce = 10f;
    private bool isJumping = false;
    private Rigidbody playerRigidbody;

    // Ground check variables
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.2f;

    private Transform playerCamera;
    private void LateUpdate()
    {
        CamHolder.transform.eulerAngles = new Vector3(m_LookRotation, CamHolder.transform.eulerAngles.y, CamHolder.transform.eulerAngles.z);

    }

    void OnEnable()
    {
        // Enable input actions
        movementAction.action.Enable();
        jumpAction.action.Enable();
        runAction.action.Enable(); // Enable the run action

        playerRigidbody = GetComponent<Rigidbody>();
        playerCamera = Camera.main.transform;
    }

    void OnDisable()
    {
        // Disable input actions
        movementAction.action.Disable();
        jumpAction.action.Disable();
        runAction.action.Disable(); // Disable the run action
    }

    public bool IsGrounded()
    {
        // Perform a raycast to check if the player is grounded
        return Physics.Raycast(transform.position, Vector3.down, 0.1f);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        // Check if the player is grounded
        bool isGrounded = IsGrounded();

        if (GameControllerManager.Instance.Pause == false)
        {
            //Turn
            transform.Rotate(Vector3.up * m_Look.x * Sensitivity);

            //Look
            m_LookRotation += (-m_Look.y * Sensitivity);
            m_LookRotation = Mathf.Clamp(m_LookRotation, -90, 90);
        }     

        if (jumpAction.action.triggered)
        {
            m_TestJump(jumpAction.action.GetBindingDisplayString());
            Debug.Log("Jump");
        }

        Vector3 down = transform.TransformDirection(Vector3.down) * groundCheckDistance;
        Debug.DrawRay(transform.position, down, Color.green);
    }

     void Move()
     {
        Vector2 movementInput = movementAction.action.ReadValue<Vector2>();

        // Get the camera's forward direction without any consideration for up/down rotation
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f; // Ensure the direction is parallel to the ground

        // Calculate movement in world space based on the camera's forward direction
        Vector3 movement = cameraForward * movementInput.y + Camera.main.transform.right * movementInput.x;

        // Apply movement with speed and run multiplier
        float speedMultiplier = runAction.action.ReadValue<float>() > 0.5f ? runMultiplier : 1f;
        Vector3 targetVelocity = movement.normalized * moveSpeed * speedMultiplier;

        //// Apply a damping force on the x and z axes
        //float xZDampingFactor = 2f; // Adjust the damping factor as needed
        //Vector3 dampingForce = new Vector3(-playerRigidbody.velocity.x, 0f, -playerRigidbody.velocity.z) * xZDampingFactor;
        //playerRigidbody.AddForce(dampingForce, ForceMode.Acceleration);

        // Set the target velocity as the desired velocity
        playerRigidbody.velocity = new Vector3(targetVelocity.x, playerRigidbody.velocity.y, targetVelocity.z);

    }

    void m_TestJump(string jumpButton)
    {

        // Apply jump force
        playerRigidbody.AddForce(Vector3.up * jumpForce);

        // Set jumping flag to true
        isJumping = true;

        // Log the jump button
        Debug.Log("Jump button pressed: " + jumpButton);

        Invoke(nameof(ResetJump), 0.1f);


    }
    void ResetJump()
    {
        isJumping = false;
    }
}
