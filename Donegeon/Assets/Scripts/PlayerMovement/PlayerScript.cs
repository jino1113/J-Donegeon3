using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody Rb;
    public GameObject CamHolder;
    public float Sensitivity;


    [Header("Movement")]
    public float OriginalSpeed;
    public float Speed;
    public float RunSpeed;
    public float MaxForce;


    private Vector2 m_Move, m_Look;
    private OnButtonInput m_Run;
    private float m_LookRotation;


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
    }

    private void FixedUpdate()
    {
        Move();
        Run();


    }

    void Update()
    {
        //Turn
        transform.Rotate(Vector3.up * m_Look.x * Sensitivity);

        //Look
        m_LookRotation += (-m_Look.y * Sensitivity);
        m_LookRotation = Mathf.Clamp(m_LookRotation, -90, 90);

    }

    private void LateUpdate()
    {
        CamHolder.transform.eulerAngles = new Vector3(m_LookRotation, CamHolder.transform.eulerAngles.y, CamHolder.transform.eulerAngles.z);

    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = RunSpeed;
        }
        else
        {
            Speed = OriginalSpeed;
        }
    }

    void Move()
    {
        //Find target velocity
        Vector3 currentVelocity = Rb.velocity;
        Vector3 targetVelocity = new Vector3(m_Move.x, 0, m_Move.y);
        targetVelocity *= Speed;

        //Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, -0.15f, velocityChange.z);

        //Limit force
        Vector3.ClampMagnitude(velocityChange, MaxForce);

        Rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void Jump()
    {

    }

}
