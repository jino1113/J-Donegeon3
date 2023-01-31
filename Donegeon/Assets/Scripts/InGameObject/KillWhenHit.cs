using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(KillWhenHit))]

public class KillWhenHit : MonoBehaviour
{
    [SerializeField] private GameObject PlayerModel;
    [SerializeField] private GameObject PlayerNowPos;
    [SerializeField] private GameObject RespawnPoint;
    [SerializeField] private bool Axe;
    [SerializeField] private bool Fire;
    [SerializeField] private bool Lava;
    [SerializeField] private bool Stew;
    [SerializeField] private bool Fall;
    [SerializeField] private bool Spike;


    void Start()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
            PlayerNowPos.transform.position = RespawnPoint.transform.position;
            GameControllerManager.Instance.isDead = true;
        }
    }
}
