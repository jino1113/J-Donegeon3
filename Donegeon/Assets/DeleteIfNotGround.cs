using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteIfNotGround : MonoBehaviour
{
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private bool IsOn;

    void Start()
    {
        Collider decalCollider = GetComponent<Collider>();
        Physics.IgnoreCollision(decalCollider, decalCollider);
        groundCheck();
    }

    void groundCheck()
    {
        Collider[] groundColliders =
            Physics.OverlapBox((new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z)),
                transform.localScale / 2, Quaternion.identity, GroundMask);

        if (groundColliders.Length <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z)), transform.localScale);
    }

}
