using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMapPanel : MonoBehaviour
{
    [SerializeField] private GameObject ExitPanelGameObject;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            GameControllerManager.Instance.Pause = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            ExitPanelGameObject.SetActive(true);
        }
    }
}
