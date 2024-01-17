using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;


public class Facerotation : MonoBehaviour
{
    [Header("Ground Check")]

    [SerializeField] private GameObject m_GroundCheckGameObject;

    public float playerHeight;
    public LayerMask whatisGround;

    [Header("Camera Animator")] 
    
    public GameObject Player;
    public Animator animator;

    public Transform cameraRotation;

    [SerializeField] private PlayerInput playerInput;

    public InputAction playerinputAction;

    int i;

    void Start()
    {
        animator = animator.GetComponent<Animator>();
        
        playerinputAction = playerInput.GetComponent<InputAction>();
    }

    void FixedUpdate()
    {
        transform.rotation = cameraRotation.rotation;
    }

    void Update()
    {
        //Movement();
        IsGround();
        Debug.DrawRay(m_GroundCheckGameObject.transform.position, -Vector3.up * playerHeight, Color.red);

        //if (playerInput.actions["Movement"].triggered || playerInput.actions["Run"].triggered)
        //{
        //    Movement();
        //    Debug.Log("Update Movement true");
        //}
    }

    void IsGround()
    {
        if (Physics.Raycast(m_GroundCheckGameObject.transform.position, -Vector3.up, playerHeight, whatisGround))
        {
            animator.SetBool("grounded", true);

        }
        else
        {
            animator.SetBool("grounded", false);
        }
    }

    void Movement(InputAction.CallbackContext context)
    {

        if (playerInput.actions["Movement"].triggered)
        {
            Debug.Log(i++);
            Debug.Log("Movement triggered == true");
            animator.SetBool("Move", true );
        }
        else
        {
            animator.SetBool("Move", false);
        }

        //if (!playerInput.actions["Movement"].triggered || !playerInput.actions["Run"].triggered)
        //{
        //    animator.SetBool("Move", false);
        //    animator.SetBool("Run", false);
        //    Debug.Log("Movement and run triggered == false");
        //}

        if (playerInput.actions["Run"].enabled)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            Debug.Log("Run triggered == true");
            animator.SetBool("Run", false);
        }
    }
}
