using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeleteAnyThingOnHit : MonoBehaviour
{
    void OnCollisionEnter(Collision collider)
    {
        Destroy(collider.transform.root.gameObject);

        Destroy(collider.gameObject);
    }
}
