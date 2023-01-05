using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOnMomentum : MonoBehaviour
{
    public List<GameObject> decalPrefabs;
    [SerializeField] private bool Ready;

    [SerializeField] private Rigidbody RB;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float bForce = 3f;

    void Start()
    {
        Ready = true;
        gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (Ready == true)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 direction = contact.point - transform.position;
                RaycastHit hit;
                if (Physics.Raycast(transform.position, direction, out hit, GroundMask))
                {
                    Debug.Log("Hit OK");
                    if (RB.velocity.magnitude > bForce)
                    {
                        Debug.Log("Velocity OK");
                        if (hit.transform == collision.transform)
                        {
                            Debug.Log("Spawn OK");
                            int index = Random.Range(0, decalPrefabs.Count);
                            GameObject decal = Instantiate(decalPrefabs[index], hit.point - (direction * -0.001f), Quaternion.LookRotation(hit.normal));
                            decal.SetActive(true);
                            StartCoroutine(SetReady());
                        }
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
        yield return new WaitForSeconds(0.1f);
        Ready = true;
    }

}
