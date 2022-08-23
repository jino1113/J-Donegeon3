using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float FallMultiply;
    public float LowjumpMultiply;

    public PlayerMove PM;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (FallMultiply - 1) * Time.deltaTime;
        }

        else if (rb.velocity.y > 0 && PM.jumpHold)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (LowjumpMultiply - 1) * Time.deltaTime;
        }
    }
}
