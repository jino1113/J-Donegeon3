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
    public float OriginalSpeed;
    public float Speed;
    public float RunSpeed;
    public float MaxForce;
    public float JumpForce;


    public Vector2 m_Move, m_Look;
    private OnButtonInput m_Run;
    private float m_LookRotation;

    //---- New input ----//
    private PlayerInput playerInput;
    private CharacterController controller;

    public void OnMove(InputAction.CallbackContext context)
    {
        m_Move = context.ReadValue<Vector2>();
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        m_Look = context.ReadValue<Vector2>();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        OriginalSpeed = Speed;

        playerInput = GetComponent<PlayerInput>();  
    }

    private void FixedUpdate()
    {
        Move();
        Run();
        m_TestJump();
    }

    void Update()
    {
        if (GameControllerManager.Instance.Pause == false)
        {
            //Turn
            transform.Rotate(Vector3.up * m_Look.x * Sensitivity);

            //Look
            m_LookRotation += (-m_Look.y * Sensitivity);
            m_LookRotation = Mathf.Clamp(m_LookRotation, -90, 90);
        }
        
        // New player input (Walk: W A S D)
        if(playerInput.actions["Movement"].triggered)
        {
            Move();
            Debug.Log("New player input (Walk: W A S D)");
        }
        
        //Vector2 inputWalk = playerInput.actions["Movement"].ReadValue<Vector2>();
        //Vector3 walk = new Vector3(inputWalk.x, 0, inputWalk.y);
        //walk = walk.x * transform.right + walk.z * transform.forward;
        //walk.y = 0f;
        //controller.Move(walk * Time.deltaTime * Speed);

        /*
        // New player input (Run)
        if (playerInput.actions["Run"].triggered)
        {
            Speed = RunSpeed;
            Debug.Log("New player input (Run true)");
        }
        if (!playerInput.actions["Run"].triggered)
        {
            Speed = OriginalSpeed;
            Debug.Log("New player input (Run false)");     
        }
        */

        // New player input (Jump)    
        if (playerInput.actions["Sheet"].triggered && Animator.GetBool("grounded")) 
        {
            m_TestJump();
            Debug.Log("New player input (Jump)");
        }
       
    }

    private void LateUpdate()
    {
        CamHolder.transform.eulerAngles = new Vector3(m_LookRotation, CamHolder.transform.eulerAngles.y, CamHolder.transform.eulerAngles.z);

    }

    void Run()
    {
        //if (Input.GetKey(KeyCode.LeftShift))

        if (playerInput.actions["Run"].triggered == true)
        {
            Speed = RunSpeed;
            Debug.Log("New player input (Run true)");
        }
        if (!playerInput.actions["Run"].triggered == false)
        {
            Speed = OriginalSpeed;
            Debug.Log("New player input (Run false)");
        }
    }

    void Move()
    {
        // New player input (Run)
        Vector2 inputWalk = playerInput.actions["Movement"].ReadValue<Vector2>();
        Vector3 currentVelocity = Rb.velocity;
        Vector3 walk = new Vector3(m_Move.x, 0, m_Move.y);
        walk *= Speed;

        walk = transform.TransformDirection(walk);
        Vector3 velocityChange = (walk - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, -0.65f, velocityChange.z);

        //Find target velocity
        //Vector3 currentVelocity = Rb.velocity;
        //Vector3 targetVelocity = new Vector3(m_Move.x, 0, m_Move.y);
        //targetVelocity *= Speed;

        //Align direction
        //targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces 
        //Vector3 velocityChange = (targetVelocity - currentVelocity);

        //Limit force
        Vector3.ClampMagnitude(velocityChange, MaxForce);

        Rb.AddForce(velocityChange, ForceMode.VelocityChange);

        //Vector2 inputWalk = playerInput.actions["Movement"].ReadValue<Vector2>();
        //Vector3 walk = new Vector3(inputWalk.x, 0, inputWalk.y);
        //walk = walk.x * transform.right + walk.z * transform.forward;
        //walk.y = 0f;
        //controller.Move(walk * Time.deltaTime * Speed);
    }

    void Jump()
    {
        Vector3 junpForcesVector3 = Vector3.zero;

        if (Animator.GetBool("grounded"))
        {
            junpForcesVector3 = Vector3.up * JumpForce;
        }

        Rb.AddForce(junpForcesVector3, ForceMode.VelocityChange);
    }

    void m_TestJump()
    {
        Vector3 junpForcesVector3 = Vector3.zero;

        // New player input
       
        if (playerInput.actions["Sheet"].triggered && Animator.GetBool("grounded") == true)
        {
            junpForcesVector3 = Vector3.up * JumpForce;
        }
        Rb.AddForce(junpForcesVector3, ForceMode.VelocityChange);
        
    }

}
