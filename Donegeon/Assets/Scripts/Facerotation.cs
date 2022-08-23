using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facerotation : MonoBehaviour
{

    [Header("Camera Animator")]

    public Animator animator;
    private bool grounded;

    public PlayerMove pm;

    public Transform cameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        animator = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = pm.grounded;
        transform.rotation = cameraRotation.rotation;

        Movement();

        animator.SetBool("grounded", grounded);
    }

    void Movement()
    {
        if (pm.horizontalInput != 0 || pm.verticalInput != 0)
        {
            animator.SetBool("Move", true);

            if (Input.GetKey(pm.RunKey))
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
