using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

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

    void Start()
    {
        animator = animator.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.rotation = cameraRotation.rotation;
    }

    void Update()
    {
        Movement();
        IsGround();
        Debug.DrawRay(m_GroundCheckGameObject.transform.position, -Vector3.up * playerHeight, Color.red);
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

    void Movement()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Move", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetBool("Run", false);
        }

    }
}
