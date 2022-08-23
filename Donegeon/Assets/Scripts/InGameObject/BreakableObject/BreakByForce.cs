using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakByForce : MonoBehaviour
{
    public GameObject breakVersion;
    public float bForce = 1f;
    protected Rigidbody rb;
    private int active = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > bForce && active == 0)
        {
            active++;
            Instantiate(breakVersion, transform.position, transform.rotation);
            rb.AddExplosionForce(10f, Vector3.zero, 0f);
            Destroy(gameObject);
        }
    }
}
