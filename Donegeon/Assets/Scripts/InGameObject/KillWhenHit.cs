using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


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
            if (Axe == true)
            {
                PointArrow.Instance.Triggers["Quest10"] = true;
                GameControllerManager.Instance.DieCounter[0] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }
            else if (Fire == true)
            {
                PointArrow.Instance.Triggers["Quest11"] = true;
                GameControllerManager.Instance.DieCounter[1] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }
            else if (Lava == true)
            {
                PointArrow.Instance.Triggers["Quest12"] = true;
                GameControllerManager.Instance.DieCounter[2] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }
            else if (Stew == true)
            {
                PointArrow.Instance.Triggers["Quest13"] = true;
                GameControllerManager.Instance.DieCounter[3] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }
            else if (Fall == true)
            {
                PointArrow.Instance.Triggers["Quest14"] = true;
                GameControllerManager.Instance.DieCounter[4] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }
            else if (Spike == true)
            {
                PointArrow.Instance.Triggers["Quest15"] = true;
                GameControllerManager.Instance.DieCounter[5] += 1;

                Instantiate(PlayerModel, collider.transform.position, Quaternion.identity);
                PlayerNowPos.transform.position = RespawnPoint.transform.position;
                GameControllerManager.Instance.isDead = true;
            }

        }
    }
}
