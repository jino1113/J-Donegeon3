using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillWhenHit : MonoBehaviour
{
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private GameObject PlayerNowPos;
    [SerializeField] private GameObject RespawnPoint;




    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
            PlayerNowPos.transform.position = RespawnPoint.transform.position;
        }
    }
}
