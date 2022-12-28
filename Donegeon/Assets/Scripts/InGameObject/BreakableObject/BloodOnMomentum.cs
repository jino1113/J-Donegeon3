using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOnMomentum : MonoBehaviour
{
    public List<GameObject> decalPrefabs;
    private bool Ready;

    [SerializeField] private Rigidbody RB;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float bForce = 3f;

    void Start()
    {
        gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (Ready == true)
        {
            Vector3 direction = other.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, GroundMask))
            {
                Debug.Log("Hit OK");
                if (RB.velocity.magnitude > bForce)
                {
                    Debug.Log("Velocity OK");
                    if (hit.transform == other.transform)
                    {
                        Debug.Log("Spawn OK");
                        int index = Random.Range(0, decalPrefabs.Count);
                        GameObject decal = Instantiate(decalPrefabs[index], hit.point - (direction * -0.005f), Quaternion.LookRotation(hit.normal));
                        decal.SetActive(true);
                        StartCoroutine(SetReady());
                    }
                }
            }
        }
        else
        {
            return;
        }
    }


    IEnumerator SetReady()
    {
        Ready = false;
        yield return new WaitForSeconds(0.05f);
        Ready = true;
    }

}
