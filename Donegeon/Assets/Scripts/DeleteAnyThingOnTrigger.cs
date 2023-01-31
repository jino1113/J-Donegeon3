using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAnyThingOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
