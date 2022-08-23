using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float movespeed;
    public float originalspeed;
    public float runspeed;
    float strife;
        
    public float groundDrag;

    public float JumpForce;
    public float JumpCooldown;
    public float AirMultiply;


    [Header("Keybind")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatisGround;

    [Header("**Debug**")]
    public bool Readytojump;
    public bool grounded;
    public bool running;
    public bool jumpHold;

    public Transform orientation;

    public float horizontalInput;
    public float verticalInput;

    Vector3 moveDirection;



    Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        Readytojump = true;

        rb = GetComponent<Rigidbody>(); 
        rb.freezeRotation = true;

        

    }

    // Update is called once per frame
    void Update()
    {
        //Ground Check

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatisGround);

        if (Input.GetKey(jumpKey))
        {
            jumpHold = true;
        }
        else
        {
            jumpHold = false;
        }

        Myinput();
        SpeedControl(); 

        //Ground drag

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }


    }

    private void FixedUpdate()
    {
        Moveplayer();
    }

    private void Myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(horizontalInput != 0)
        {
            strife = 0.9f;
        }
        
        else if (verticalInput < 0)
        {
            strife = 0.75f;
        }
        else
        {
            strife = 1f;
        }

        if (Input.GetKey(jumpKey) && grounded && Readytojump)
        {
            Readytojump = false;

            Jump();

            Invoke(nameof(ResetJump), JumpCooldown);
        }

            if (Input.GetKey(RunKey))
        {
            if (grounded)
            {
                movespeed = runspeed * strife;
                running = true;
            }
        }
        else
        {
            if (grounded)
            {
                movespeed = originalspeed * strife;
                running = false;
            }
            
        }

    }

   private void Moveplayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //Grounded
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * movespeed * 10f, ForceMode.Force);
        }

        //Air
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * movespeed * 10f * AirMultiply, ForceMode.Force);
        }

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > movespeed)
        {
            Vector3 limitedVel = flatVel.normalized * movespeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        Readytojump = true;
    }

    
}
